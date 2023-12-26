using Microsoft.EntityFrameworkCore;
using PashaBank.Core.Models;
using PashaBank.Core.Models.Enums;

namespace PashaBank.Repository.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasKey(u => u.UserId);

            builder.Entity<User>()
                .HasMany(u => u.RecommendedUsers)
                .WithOne(r => r.Recommender)
                .HasForeignKey(u => u.RecommenderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasKey(p => p.ProductId);

            builder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            builder.Entity<Sale>()
                .HasOne(s => s.Distributor)
                .WithMany(u => u.Sales)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Recommendation>()
                .HasKey(r => r.RecommendationId);

            builder.Entity<Recommendation>()
                .HasOne(r => r.Recommender)
                .WithMany(u => u.Recommendations)
                .HasForeignKey(r => r.RecommenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Recommendation>()
                .HasOne(r => r.RecommendedUser)
                .WithMany()
                .HasForeignKey(r => r.RecommendedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bonus>()
                .HasKey(b => b.BonusId);

            builder.Entity<Bonus>()
                .HasOne(b => b.Distributor)
                .WithMany(u => u.Bonuses)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
