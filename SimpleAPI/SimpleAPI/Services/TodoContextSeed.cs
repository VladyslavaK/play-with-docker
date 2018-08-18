using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class TodoContextSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var context = (ToDoContext)services
                .GetService(typeof(ToDoContext));
            using (context)
            {
               // context.Database.Migrate();
                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(
                        GetPreconfiguredCatalogBrands());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<ToDoTask> GetPreconfiguredCatalogBrands()
        {
            return new List<ToDoTask>()
       {
           new ToDoTask() { Description = "Azure"},
           new ToDoTask() { Description = ".NET" },
           new ToDoTask() { Description = "Visual Studio" },
           new ToDoTask() { Description = "SQL Server" }
       };
        }
    }
}
