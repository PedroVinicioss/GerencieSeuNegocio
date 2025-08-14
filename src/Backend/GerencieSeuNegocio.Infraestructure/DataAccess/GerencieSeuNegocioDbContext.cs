using GerencieSeuNegocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerencieSeuNegocio.Infraestructure.DataAccess
{
    public class GerencieSeuNegocioDbContext : DbContext
    {
        public GerencieSeuNegocioDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CashReport> CashReports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleItems> SaleItems { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<StayCustomer> StayCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerencieSeuNegocioDbContext).Assembly);
        }
    }
}
