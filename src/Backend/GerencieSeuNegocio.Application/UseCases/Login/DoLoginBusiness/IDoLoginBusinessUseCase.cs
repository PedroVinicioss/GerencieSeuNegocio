using GerencieSeuNegocio.Communication.Requests.Login.DoLoginBusiness;
using GerencieSeuNegocio.Communication.Responses.User.Create;

namespace GerencieSeuNegocio.Application.UseCases.Login.DoLoginBusiness
{
    public interface IDoLoginBusinessUseCase
    {
        public Task<ResponseCreateUserJson> Execute(RequestDoLoginBusinessJson request, CancellationToken cancellationToken = default);
    }
}
