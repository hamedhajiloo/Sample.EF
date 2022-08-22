
// Ensure database is created and has a person in it
using Sample.EF;
using Sample.EF.Model;
using System.Diagnostics;

var sw1 = Stopwatch.StartNew();
using (var setupContext = new TestDbContext())
{
    //setupContext.Database.EnsureDeleted();
    setupContext.Database.EnsureCreated();
    var list = new List<Person>();
    for (int i = 0; i < 1000; i++)
    {
        var person = new Person(true) { Name = "Alaki" };
        list.Add(person);
    }

    setupContext.People.AddRange(list);

    await setupContext.SaveChangesAsync();
    sw1.Stop();

    foreach (var p in list)
    {
        Console.Write($"{p.EasyKey}|");
    }
}

Console.WriteLine();
Console.WriteLine("_____________ END of SaveChangesAsync _____________");
Console.WriteLine();
Console.WriteLine($"time of SaveChangesAsync : {sw1.ElapsedMilliseconds}");
Console.WriteLine();

sw1.Restart();

using (var setupContext = new TestDbContext())
{
    //setupContext.Database.EnsureDeleted();
    setupContext.Database.EnsureCreated();
    var list = new List<Person>();
    for (int i = 0; i < 1000; i++)
    {
        var person = new Person(true) { Name = "Alaki" };
        list.Add(person);
    }

    setupContext.People.AddRange(list);

    await setupContext.BulkSaveChangesAsync();
    sw1.Stop();

    foreach (var p in list)
    {
        Console.Write($"{p.EasyKey}|");
    }
}

Console.WriteLine();
Console.WriteLine("_____________ END of BulkSaveChangesAsync _____________");
Console.WriteLine();
Console.WriteLine($"time of BulkSaveChangesAsync : {sw1.ElapsedMilliseconds}");
Console.WriteLine();



