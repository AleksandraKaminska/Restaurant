using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class MenuItemEntityTypeConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Menu)
                .WithMany(p => p.MenuItems);
        }
    }
}