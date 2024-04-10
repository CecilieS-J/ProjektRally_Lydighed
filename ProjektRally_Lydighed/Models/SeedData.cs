using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Models;
using System;
using System.Linq;

namespace ProjektRally_Lydighed.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjektRally_LydighedContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjektRally_LydighedContext>>()))
            {
                // Tjek om der allerede er nogen tracks.
                if (context.Track.Any())
                {
                    return;   // Databasen er allerede fyldt
                }

                context.Track.AddRange(
                    new Track
                    {
                        Name = "Track 1",
                        Comment = "This is the first track",
                        Location = "Location 1",
                        ReleaseDate = new DateTime(2022, 1, 1)
                    },
                    new Track
                    {
                        Name = "Track 2",
                        Comment = "This is the second track",
                        Location = "Location 2",
                        ReleaseDate = new DateTime(2022, 2, 1)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
