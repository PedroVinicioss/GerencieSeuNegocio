using GerencieSeuNegocio.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;
using System;

namespace GerencieSeuNegocio.Infraestructure.DataAccess.Repositories
{
    public class BusinessRepository : IBusinessReadOnlyRepository, IBusinessWriteOnlyRepository
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

        #region Read Operations

        public async Task<bool> ExistActiveBusinessUuid(Guid uuid, CancellationToken cancellationToken = default) => await _dbContext.Business.AnyAsync(u => u.Uuid.Equals(uuid) && u.Active);

        #endregion
    }
}
