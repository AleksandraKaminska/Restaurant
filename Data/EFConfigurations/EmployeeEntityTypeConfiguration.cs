using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasDiscriminator<int>("EmployeeType")
                .HasValue<Waiter>(1);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.PhoneNumbers).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Property(e => e.EmploymentDate).IsRequired();
            builder.Property(e => e.HourlyRate).IsRequired();
            builder.HasOne(e => e.Local)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.Id);
        }
    }
}
