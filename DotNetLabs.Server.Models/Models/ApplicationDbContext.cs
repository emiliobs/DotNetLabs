using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetLabs.Server.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PlayList> playLists { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<PlayListVideo> playListVideos { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                 .HasMany(p => p.CreateVideos)
                 .WithOne(p => p.CreateByUser)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(p => p.ModifiedVideos)
                   .WithOne(p => p.ModifiedByUser)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                 .HasMany(p => p.CreatePlayLists)
                 .WithOne(p => p.CreateByUser)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(p => p.ModifiedPlayLists)
                   .WithOne(p => p.ModifiedByUser)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(p => p.CreatedComments)
                .WithOne(p => p.CreateByUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(p => p.ModifiedComments)
                   .WithOne(p => p.ModifiedByUser)
                   .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

    }
}
