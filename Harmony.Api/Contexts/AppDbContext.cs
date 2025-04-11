using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Song>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Interaction>()
                .HasKey(i => new { i.UserId, i.SongId, i.InteractionTypeId });
            modelBuilder.Entity<Interaction>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Interaction>()
                .HasOne<Song>()
                .WithMany()
                .HasForeignKey(i => i.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Interaction> Interactions { get; set; } = null!;
    }
}
