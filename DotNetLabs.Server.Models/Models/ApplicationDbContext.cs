using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        private string _userId = null;

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


        public async Task SaveChangesAsync(string userId)
        {
            _userId = userId;
            await SaveChangesAsync();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is UserRecord)
                {
                    var userRecord = (UserRecord)item.Entity;

                    switch (item.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            break;
                        case EntityState.Modified:
                            userRecord.ModificationDate = DateTime.UtcNow;
                            userRecord.ModifiedByUserId = _userId;
                            break;
                        case EntityState.Added:
                            userRecord.ModificationDate = DateTime.UtcNow;
                            userRecord.ModifiedByUserId = _userId;
                            userRecord.CreationDate = DateTime.UtcNow;
                            userRecord.CreateByUserId = _userId;
                            break;
                        default:
                            break;
                    }

                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
