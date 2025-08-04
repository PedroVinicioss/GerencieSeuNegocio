using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Responses.User.Create;

namespace GerencieSeuNegocio.Application.UseCases.User.Create
{
    public interface ICreateUserUseCase
    {
        public Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request);
    }
}
