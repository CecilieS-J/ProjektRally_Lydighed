using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rally_Lydighed.Models;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Data
{
    public class ProjektRally_LydighedContext : DbContext
    {
        public ProjektRally_LydighedContext (DbContextOptions<ProjektRally_LydighedContext> options)
            : base(options)
        {
        }

        public DbSet<Rally_Lydighed.Models.User> User { get; set; } = default!;
        public DbSet<ProjektRally_Lydighed.Models.Track> Track { get; set; } = default!;
    }
}
