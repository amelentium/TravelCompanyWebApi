using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompany.Domain.Entity;

namespace TravelCompany.Infrastructure.Persistence.Configuration
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Address)
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .HasMaxLength(20);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(20);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15);
        }
    }
}
