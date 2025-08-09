using GerencieSeuNegocio.Domain.Repositories.Business;

namespace GerencieSeuNegocio.Infraestructure.DataAccess.Repositories
{
    public class BusinessRepository : IBusinessWriteOnlyRepository
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;
        public BusinessRepository(GerencieSeuNegocioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Write Operations

        public async Task Add(Domain.Entities.Business business)
        {
            await _dbContext.Business.AddAsync(business);
        }

        #endregion
    }
}
