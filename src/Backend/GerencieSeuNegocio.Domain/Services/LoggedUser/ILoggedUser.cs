using GerencieSeuNegocio.Domain.Entities;

namespace GerencieSeuNegocio.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        public Task<User> User();
    }
}
