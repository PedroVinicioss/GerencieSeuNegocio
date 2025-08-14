namespace GerencieSeuNegocio.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistActiveUserWithEmail(string email, CancellationToken cancellationToken = default);
        public Task<bool> ExistActiveUserWithUuid(Guid uuid, CancellationToken cancellationToken = default);
        public Task<Entities.User?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken = default);
        public Task<bool> ExistActiveBusinessOfUser(Guid userUuid, Guid businessUuid, CancellationToken cancellationToken = default);
    }
}
