using GerencieSeuNegocio.Domain.Entities;

namespace GerencieSeuNegocio.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        public Task<User> User(CancellationToken cancellationToken = default);
        public Task<Business> Business(CancellationToken cancellationToken = default);
    }
}
