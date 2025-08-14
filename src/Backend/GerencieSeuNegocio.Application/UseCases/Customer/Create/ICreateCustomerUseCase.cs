using GerencieSeuNegocio.Communication.Requests.Customer.Create;
using GerencieSeuNegocio.Communication.Responses.Customer.Profile;

namespace GerencieSeuNegocio.Application.UseCases.Customer.Create
{
    public interface ICreateCustomerUseCase
    {
        public Task<ResponseCreateCustomerJson> Execute(RequestCreateCustomerJson request, CancellationToken cancellationToken = default);
    }
}
