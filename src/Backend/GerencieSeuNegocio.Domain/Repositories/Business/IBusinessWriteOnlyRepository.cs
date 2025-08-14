namespace GerencieSeuNegocio.Domain.Repositories.Business
{
    public interface IBusinessWriteOnlyRepository
    {
        Task Add(Domain.Entities.Business business, CancellationToken cancellationToken = default);
    }
}
