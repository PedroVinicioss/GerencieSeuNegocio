namespace GerencieSeuNegocio.Domain.Repositories.Customer
{
    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Domain.Entities.Customer customer, CancellationToken cancellationToken = default);
    }
}
