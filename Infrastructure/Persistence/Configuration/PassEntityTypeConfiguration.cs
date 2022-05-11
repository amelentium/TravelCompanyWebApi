using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompany.Domain.Entity;

namespace TravelCompany.Infrastructure.Persistence.Configuration
{
    public class PassEntityTypeConfiguration : IEntityTypeConfiguration<Pass>
    {
        public void Configure(EntityTypeBuilder<Pass> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PurchaseDate)
                .HasPrecision(0);

            builder.HasOne(d => d.Client)
                .WithMany(p => p.Passes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Passes_Clients");

            builder.HasOne(d => d.Tour)
                .WithMany(p => p.Passes)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Passes_Tours");
        }
    }
}
