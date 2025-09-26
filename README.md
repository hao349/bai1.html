using Microsoft.EntityFrameworkCore;
using TourBookingApp.Models;

namespace TourBookingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("Tours");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(255);
                entity.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(t => t.Duration).IsRequired();
                entity.Property(t => t.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Bookings");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.BookingDate).IsRequired();
                entity.Property(b => b.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(b => b.CustomerEmail).IsRequired().HasMaxLength(100);
                entity.Property(b => b.NumberOfPeople).IsRequired();
                entity.HasOne(b => b.Tour)
                      .WithMany(t => t.Bookings)
                      .HasForeignKey(b => b.TourId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
