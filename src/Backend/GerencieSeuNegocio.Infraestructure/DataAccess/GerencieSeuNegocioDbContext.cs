using GerencieSeuNegocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerencieSeuNegocio.Infraestructure.DataAccess
{
    public class GerencieSeuNegocioDbContext : DbContext
    {
        public GerencieSeuNegocioDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerencieSeuNegocioDbContext).Assembly);
        }
    }
}
