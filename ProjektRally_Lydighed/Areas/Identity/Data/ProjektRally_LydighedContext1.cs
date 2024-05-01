using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektRally_Lydighed.Areas.Identity.Data;

namespace ProjektRally_Lydighed.Data;

public class ProjektRally_LydighedContext1 : IdentityDbContext<ProjektRally_Lydighed1>
{
    public ProjektRally_LydighedContext1(DbContextOptions<ProjektRally_LydighedContext1> options)
        : base(options)
    {
    }

    public DbSet<ProjektRally_Lydighed.Models.User> User { get; set; } = default!;
    public DbSet<ProjektRally_Lydighed.Models.Track> Track { get; set; } = default!;
    public DbSet<ProjektRally_Lydighed.Models.Sign> Sign { get; set; } = default!;
    public DbSet<ProjektRally_Lydighed.Models.Exercise> Exercise { get; set; } = default!;
    public DbSet<ProjektRally_Lydighed.Models.Category> Category { get; set; } = default!;
    public DbSet<ProjektRally_Lydighed.Models.Equipment> Equipment { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ProjektRally_Lydighed1>
    {
        public void Configure(EntityTypeBuilder<ProjektRally_Lydighed1> builder) 
        { 
            builder.Property( x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
        }
    }
}
