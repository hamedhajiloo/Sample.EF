using Microsoft.EntityFrameworkCore;
using Sample.EF.Model;

namespace Sample.EF
{
    public class TestDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Requires NuGet package Microsoft.EntityFrameworkCore.SqlServer
            optionsBuilder.UseSqlServer(
                @"Server=.;Initial Catalog=SampleEfCore;Integrated Security=True;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=3000;App=Sample");
        }
    }
}
