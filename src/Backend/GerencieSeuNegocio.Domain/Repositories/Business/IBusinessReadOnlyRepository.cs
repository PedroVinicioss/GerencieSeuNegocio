namespace GerencieSeuNegocio.Domain.Repositories.Business
{
    public interface IBusinessReadOnlyRepository
    {
        Task<bool> ExistActiveBusinessUuid(Guid uuid, CancellationToken cancellationToken = default);
    }
}
