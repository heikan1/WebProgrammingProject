using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models.db
{
    public class Db : DbContext
    {
        public DbSet<Person> Person_t { get; set; }
        public DbSet<Customer> Customer_t { get; set; }
        public DbSet<Barber> Barber_t { get; set; }
        public DbSet<Shop> Shop_t{ get; set; }
        public DbSet<Shopkeeper> Shopkeeper_t { get; set; }
        public DbSet<Rendezvous> Rendezvous_t { get; set; }
        public DbSet<AvailableTime> AvailableTime_t { get; set; }

        public Db(DbContextOptions<Db> options) : base(options) { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("<connection string>");
        }*/
    }
}
