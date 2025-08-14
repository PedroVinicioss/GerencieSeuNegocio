namespace GerencieSeuNegocio.Domain.Repositories.Customer
{
    public interface ICustomerReadOnlyRepository
    {
        Task<Domain.Entities.Customer?> GetByDocument(string document, int businessId, CancellationToken cancellationToken = default);
    }
}
