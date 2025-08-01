using GerencieSeuNegocio.Communication.Requests.User.Register;
using GerencieSeuNegocio.Communication.Responses.User.Register;

namespace GerencieSeuNegocio.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
