using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace WebProgrammingProject.Models.db
{
   
    public class Db : DbContext
    {
        public DbSet<Customer> Customer_t { get; set; }
        public DbSet<Barber> Barber_t { get; set; }
        public DbSet<Shop> Shop_t{ get; set; }
        public DbSet<Shopkeeper> Shopkeeper_t { get; set; }
        public DbSet<Rendezvous> Rendezvous_t { get; set; }
        public DbSet<AvailableTime> AvailableTime_t { get; set; }
        public DbSet<Proficiencies>Proficiencies_t{ get; set; }

        public Db(DbContextOptions<Db> options) : base(options) { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("<connection string>");
        }*/
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.StartTime)
                      .HasConversion(
                          v => v.ToString(),          // Convert TimeSpan to string
                          v => TimeOnly.Parse(v));     // Convert string back to TimeSpan

                entity.Property(e => e.EndTime)
                      .HasConversion(
                          v => v.ToString(),
                          v => TimeOnly.Parse(v));
            });
        }*/
   
    }
}
