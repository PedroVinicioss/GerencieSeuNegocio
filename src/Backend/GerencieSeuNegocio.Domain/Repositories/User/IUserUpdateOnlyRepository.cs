namespace GerencieSeuNegocio.Domain.Repositories.User
{
    public interface IUserUpdateOnlyRepository
    {
        public void Update(Entities.User user);
    }
}
