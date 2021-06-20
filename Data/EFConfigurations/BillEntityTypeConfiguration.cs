using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class BillEntityTypeConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Order)
                .WithMany(p => p.Bills);

            builder.HasOne(e => e.Payment)
                .WithOne(p => p.Bill)
                .HasForeignKey<Payment>(p => p.Id);
        }
    }
}