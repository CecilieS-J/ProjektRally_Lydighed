using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Data
{
    public class ProjektRally_LydighedContext : DbContext
    {
        public ProjektRally_LydighedContext (DbContextOptions<ProjektRally_LydighedContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektRally_Lydighed.Models.User> User { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Track> Track { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Sign> Sign { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Category> Category { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Equipment> Equipment { get; set; } = default!;
    }
}
