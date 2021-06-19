using Microsoft.EntityFrameworkCore;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Infrastructure.Context
{
    public partial class TravelCompanyDBContext : DbContext
    {
        public TravelCompanyDBContext() { }

        public TravelCompanyDBContext(DbContextOptions<TravelCompanyDBContext> options) : base(options) { }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Climate> Climates { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Duration> Durations { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<PassDiscount> PassDiscounts { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-V7A60DF\\SQLSERVER;Initial Catalog=TravelCompanyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Climate)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ClimateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Cities_Climates");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<Climate>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Duration>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Hotels_Cities");
            });

            modelBuilder.Entity<Pass>(entity =>
            {
                entity.Property(e => e.FinalPrice).HasComputedColumnSql("([dbo].[computeFinalPrice]([Id],[TourId],[Count]))", false);

                entity.Property(e => e.FullPrice).HasComputedColumnSql("([dbo].[computeFullPrice]([TourId],[Count]))", false);

                entity.Property(e => e.PurchaseDate).HasPrecision(0);

                entity.Property(e => e.TotalDiscount).HasComputedColumnSql("([dbo].[computeFullDiscount]([Id]))", false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Passes_Clients");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Passes_Tours");
            });

            modelBuilder.Entity<PassDiscount>(entity =>
            {
                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.PassDiscounts)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PassDiscounts_Discounts");

                entity.HasOne(d => d.Pass)
                    .WithMany(p => p.PassDiscounts)
                    .HasForeignKey(d => d.PassId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PassDiscounts_Passes");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(80);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Duration)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.DurationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_Durations");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_Hotels");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
