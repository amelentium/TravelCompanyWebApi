using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompany.Domain.Entity;

namespace TravelCompany.Infrastructure.Persistence.Configuration
{
    public class PassDiscountEntityTypeConfiguration : IEntityTypeConfiguration<PassDiscount>
    {
        public void Configure(EntityTypeBuilder<PassDiscount> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(d => d.Discount)
                .WithMany(p => p.PassDiscounts)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_PassDiscounts_Discounts");

            builder.HasOne(d => d.Pass)
                .WithMany(p => p.PassDiscounts)
                .HasForeignKey(d => d.PassId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_PassDiscounts_Passes");
        }
    }
}
