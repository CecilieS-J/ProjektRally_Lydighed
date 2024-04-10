using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektRally_Lydighed.Data;
using Rally_Lydighed.Models;
using System;

namespace ProjektRally_Lydighed.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjektRally_LydighedContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjektRally_LydighedContext>>()))
            {
                // Tjek om der allerede er nogen brugere.
                if (context.User.Any())
                {
                    return;   // Databasen er allerede fyldt
                }
                context.User.AddRange(
                    new User
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        UserName = "johndoe",
                        Password = "password123"
                    },
                    new User
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane.smith@example.com",
                        UserName = "janesmith",
                        Password = "password456"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
