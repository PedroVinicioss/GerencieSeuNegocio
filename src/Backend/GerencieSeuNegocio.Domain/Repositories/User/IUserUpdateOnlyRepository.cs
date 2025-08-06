namespace GerencieSeuNegocio.Domain.Repositories.User
{
    public interface IUserUpdateOnlyRepository
    {
        public Task<Entities.User> GetByUuid(Guid uuid);
        public void Update(Entities.User user);
    }
}
