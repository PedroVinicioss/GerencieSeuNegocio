using GerencieSeuNegocio.Communication.Requests.User.Login;
using GerencieSeuNegocio.Communication.Responses.User.Create;

namespace GerencieSeuNegocio.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        public Task<ResponseCreateUserJson> Execute(RequestLoginJson request);
    }
}
