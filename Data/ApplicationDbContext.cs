using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restaurant.Data.EFConfigurations;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Employee> Employee { get; set; }
        // public DbSet<Employee> Locals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new WaiterEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new ChefEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new BillEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new OrderMenuItemEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new MenuItemEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new TableItemEntityTypeConfiguration());
            // modelBuilder.ApplyConfiguration(new PaymentItemEntityTypeConfiguration());
        }
    }
}
