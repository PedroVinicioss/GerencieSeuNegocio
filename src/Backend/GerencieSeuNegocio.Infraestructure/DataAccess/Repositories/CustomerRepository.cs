using GerencieSeuNegocio.Domain.Entities;
using GerencieSeuNegocio.Domain.Repositories.Customer;
using Microsoft.EntityFrameworkCore;

namespace GerencieSeuNegocio.Infraestructure.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;
        public CustomerRepository(GerencieSeuNegocioDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Customer customer, CancellationToken cancellationToken)
        {
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
        }

        public async Task<Customer?> GetByDocument(string document, int businessId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Active && c.BusinessId == businessId && c.Document == document, cancellationToken);
        }
    }
}
