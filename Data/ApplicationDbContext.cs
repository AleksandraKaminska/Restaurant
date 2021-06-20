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
        
        public DbSet<Local> Locals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Waiter> Waiter { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TableEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BillEntityTypeConfiguration());
        }
    }
}
