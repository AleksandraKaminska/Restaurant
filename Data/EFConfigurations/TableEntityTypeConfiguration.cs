using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class TableEntityTypeConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.Status).HasConversion(
                v => v.ToString(),
                v => (Table.StatusType)Enum.Parse(typeof(Table.StatusType), v));
            builder.Property(e => e.NrOfSeats).IsRequired();
        }
    }
}
