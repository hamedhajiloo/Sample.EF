using Microsoft.EntityFrameworkCore;
using Sample.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EF
{
    public class ConcurrencyHandlingCode
    {
        public async Task Handle()
        {
            #region ConcurrencyHandlingCode
            using var context = new TestDbContext();
            // Fetch a person from database and change phone number
            //var person = context.People.Single(p => p.Id == 1);
            //person.PhoneNumber = "555-555-5555";

            // Change the person's name in the database to simulate a concurrency conflict
            context.Database.ExecuteSqlRaw(
                "UPDATE dbo.People SET FirstName = 'Jane' WHERE PersonId = 1");

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Person)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }
            #endregion

        }
    }
}
