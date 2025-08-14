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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerencieSeuNegocioDbContext).Assembly);
        }
    }
}
