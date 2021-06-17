using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}