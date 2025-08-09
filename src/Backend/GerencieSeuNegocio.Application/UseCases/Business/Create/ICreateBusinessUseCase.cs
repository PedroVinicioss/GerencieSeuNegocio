using GerencieSeuNegocio.Communication.Requests.Business.Create;
using GerencieSeuNegocio.Communication.Responses.Business.Create;

namespace GerencieSeuNegocio.Application.UseCases.Business.Create
{
    public interface ICreateBusinessUseCase
    {
        public Task<ResponseCreateBusinessJson> Execute(RequestCreateBusinessJson request);
    }
}
