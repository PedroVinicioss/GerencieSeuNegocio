using GerencieSeuNegocio.API.Attributes;
using GerencieSeuNegocio.Communication.Requests.Business.Create;
using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Communication.Responses.Business.Create;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class BusinessController : GerencieSeuNegocioBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateBusinessJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [AuthenticatedUser]
        public async Task<IActionResult> Create(
            [FromServices] ICreateBusinessUseCase useCase,
            [FromBody] RequestCreateBusinessJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
