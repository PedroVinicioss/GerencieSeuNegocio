using GerencieSeuNegocio.API.Attributes;
using GerencieSeuNegocio.Application.UseCases.Customer.Create;
using GerencieSeuNegocio.Communication.Requests.Customer.Create;
using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Communication.Responses.Customer.Profile;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class CustomerController : GerencieSeuNegocioBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateCustomerJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [AuthenticatedUserBusiness]
        public async Task<IActionResult> Create(
            [FromServices] ICreateCustomerUseCase useCase,
            [FromBody] RequestCreateCustomerJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
