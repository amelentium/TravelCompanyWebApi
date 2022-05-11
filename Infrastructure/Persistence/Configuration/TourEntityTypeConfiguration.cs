using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompany.Domain.Entity;

namespace TravelCompany.Infrastructure.Persistence.Configuration
{
    public class TourEntityTypeConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(80);

            builder.Property(e => e.StartDate)
                .HasColumnType("date");

            builder.HasOne(d => d.Hotel)
                .WithMany(p => p.Tours)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Tours_Hotels");
        }
    }
}
