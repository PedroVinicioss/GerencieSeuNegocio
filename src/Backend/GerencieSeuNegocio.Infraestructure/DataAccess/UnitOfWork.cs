using GerencieSeuNegocio.Domain.Repositories;

namespace GerencieSeuNegocio.Infraestructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;

        public UnitOfWork(GerencieSeuNegocioDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
