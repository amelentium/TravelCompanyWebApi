using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompany.Domain.Entity;
using TravelCompany.Domain.Enum;

namespace TravelCompany.Infrastructure.Persistence.Configuration
{
    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(20);

            builder.Property(e => e.Climate)
                .HasMaxLength(20)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Climate>(v));

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Cities_Countries");
        }
    }
}
