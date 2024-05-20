using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Models;
using System;

namespace ProjektRally_Lydighed.Models
{


    public class SeedData
    {
        /*public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjektRally_LydighedContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjektRally_LydighedContext>>()))
            {
                // Tjek om der allerede er nogen brugere.
                if (!context.User.Any())
                {
                    // Tilføj seed data for brugere, hvis der ikke er nogen i databasen
                    SeedUsers(context);
                }

                // Tilføj seed data for Tracks
                if (!context.Track.Any())
                {
                    SeedTracks(context);
                }

                // Tilføj seed data for Signs
                if (!context.Sign.Any())
                {
                    SeedSigns(context);
                }

                // Tilføj seed data for Exercises
                if (!context.Exercise.Any())
                {
                    SeedExercises(context);
                }

                // Tilføj seed data for Equipment
                if (!context.Equipment.Any())
                {
                    SeedEquipment(context);
                }

                // Tilføj seed data for Category
                if (!context.Category.Any())
                {
                    SeedCategories(context);
                }
            }
        }

        private static void SeedUsers(ProjektRally_LydighedContext context)
        {
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

        private static void SeedTracks(ProjektRally_LydighedContext context)
        {
            var track1 = new Track
            {
                Name = "Track 1",
                Location = "Location 1",
                ReleaseDate = DateTime.Now,
                Category = new Category { Type = CategoryType.Begynder, NumberOfExercise = 5, Rules = "Rules for track 1" }
            };

            var track2 = new Track
            {
                Name = "Track 2",
                Location = "Location 2",
                ReleaseDate = DateTime.Now,
                Category = new Category { Type = CategoryType.Champion, NumberOfExercise = 7, Rules = "Rules for track 2" }
            };

            context.Track.AddRange(track1, track2);
            context.SaveChanges();
        }

        private static void SeedSigns(ProjektRally_LydighedContext context)
        {
            // Tilføj seed data for tegn
            // Eksempel:
            var sign1 = new Sign
            {
                SignNumber = 1,
                XCoordinate = "X1",
                YCoordinate = "Y1",
                Rotation = "Rotation1"
            };

            var sign2 = new Sign
            {
                SignNumber = 2,
                XCoordinate = "X2",
                YCoordinate = "Y2",
                Rotation = "Rotation2"
            };

            context.Sign.AddRange(sign1, sign2);
            context.SaveChanges();
        }

        private static void SeedExercises(ProjektRally_LydighedContext context)
        {
            // Tilføj seed data for øvelser
            // Eksempel:
            var exercise1 = new Exercise
            {
                Name = "Exercise 1",
                Description = "Description for Exercise 1",
                ExerciseNr = 1,
                Equipment = new Equipment { Name = "Equipment 1", Image = "Image1" },
                Category = new Category { Type = CategoryType.Begynder, NumberOfExercise = 5, Rules = "Rules for Exercise 1" }
            };

            var exercise2 = new Exercise
            {
                Name = "Exercise 2",
                Description = "Description for Exercise 2",
                ExerciseNr = 2,
                Equipment = new Equipment { Name = "Equipment 2", Image = "Image2" },
                Category = new Category { Type = CategoryType.Øvet, NumberOfExercise = 7, Rules = "Rules for Exercise 2" }
            };

            context.Exercise.AddRange(exercise1, exercise2);
            context.SaveChanges();
        }

        private static void SeedEquipment(ProjektRally_LydighedContext context)
        {
            // Tilføj seed data for udstyr
            // Eksempel:
            var equipment1 = new Equipment
            {
                Name = "Equipment 1",
                Image = "Image1",
                Exercises = new List<Exercise>()
            };

            var equipment2 = new Equipment
            {
                Name = "Equipment 2",
                Image = "Image2",
                Exercises = new List<Exercise>()
            };

            context.Equipment.AddRange(equipment1, equipment2);
            context.SaveChanges();
        }

        private static void SeedCategories(ProjektRally_LydighedContext context)
        {
            // Tilføj seed data for kategorier
            // Eksempel:
            var category1 = new Category
            {
                Type = CategoryType.Begynder,
                NumberOfExercise = 5,
                Rules = "Rules for Category 1"
            };

            var category2 = new Category
            {
                Type = CategoryType.Champion,
                NumberOfExercise = 7,
                Rules = "Rules for Category 2"
            };

            context.Category.AddRange(category1, category2);
            context.SaveChanges();
        }
    }*/

        /*  public static void Initialize(IServiceProvider serviceProvider)
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
              }


          }*/
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjektRally_LydighedContext1(
                serviceProvider.GetRequiredService<DbContextOptions<ProjektRally_LydighedContext1>>()))
            {
                // Tjek om der allerede er nogen brugere.
                if (!context.User.Any())
                {
                    // Tilføj seed data for brugere, hvis der ikke er nogen i databasen
                    SeedUsers(context);
                }

                // Tjek om der allerede er nogen spor.
                if (!context.Track.Any())
                {
                    // Tilføj seed data for spor, hvis der ikke er nogen i databasen
                    SeedTracks(context);
                }
            }
        }

        private static void SeedUsers(ProjektRally_LydighedContext1 context)
        {
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

        private static void SeedTracks(ProjektRally_LydighedContext1 context)
        {
            var categoryType1 = CategoryType.Begynder;
            var categoryType2 = CategoryType.Champion;

            var category1 = new Category { Type = categoryType1, NumberOfExercise = 5, Rules = "Rules for track 1" };
            var category2 = new Category { Type = categoryType2, NumberOfExercise = 7, Rules = "Rules for track 2" };

            context.Category.AddRange(category1, category2);
            context.SaveChanges();

            var track1 = new Track
            {
                Name = "Track 1",
                Location = "Location 1",
                ReleaseDate = DateTime.Now,
                Category = category1
            };

            var track2 = new Track
            {
                Name = "Track 2",
                Location = "Location 2",
                ReleaseDate = DateTime.Now,
                Category = category2
            };

            context.Track.AddRange(track1, track2);
            context.SaveChanges();
        }

    }
}
