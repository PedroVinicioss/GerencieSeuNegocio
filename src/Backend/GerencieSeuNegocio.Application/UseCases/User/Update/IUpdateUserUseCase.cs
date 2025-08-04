using GerencieSeuNegocio.Communication.Requests.User.Update;

namespace GerencieSeuNegocio.Application.UseCases.User.Update
{
    public interface IUpdateUserUseCase
    {
        public Task Execute(RequestUpdateUserJson request);
    }
}
