using Microsoft.EntityFrameworkCore;
using TravelCompany.Domain.Entity;

namespace Infrastructure.Persistence
{
    public partial class TravelCompanyContext : DbContext
    {
        public TravelCompanyContext(DbContextOptions<TravelCompanyContext> options) : base(options) { }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<PassDiscount> PassDiscounts { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TravelCompanyDB;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelCompanyContext).Assembly);
        }
    }
}
