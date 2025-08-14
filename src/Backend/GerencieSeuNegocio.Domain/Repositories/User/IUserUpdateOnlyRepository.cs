namespace GerencieSeuNegocio.Domain.Repositories.User
{
    public interface IUserUpdateOnlyRepository
    {
        public Task<Entities.User> GetByUuid(Guid uuid, CancellationToken cancellationToken = default);
        public void Update(Entities.User user);
    }
}
