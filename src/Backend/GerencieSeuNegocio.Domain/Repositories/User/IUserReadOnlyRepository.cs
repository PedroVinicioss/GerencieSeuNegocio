namespace GerencieSeuNegocio.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistActiveUserWithEmail(string email);
        public Task<bool> ExistActiveUserWithUuid(Guid uuid);
        public Task<Entities.User?> GetByEmailAndPassword(string email, string password);
        public Task<bool> ExistActiveBusinessOfUser(Guid userUuid, Guid businessUuid);
    }
}
