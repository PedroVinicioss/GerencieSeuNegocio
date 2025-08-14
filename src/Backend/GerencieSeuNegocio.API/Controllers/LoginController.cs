using GerencieSeuNegocio.Application.UseCases.Login.DoLogin;
using GerencieSeuNegocio.Application.UseCases.Login.DoLoginBusiness;
using GerencieSeuNegocio.Communication.Requests.Login.DoLogin;
using GerencieSeuNegocio.Communication.Requests.Login.DoLoginBusiness;
using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class LoginController : GerencieSeuNegocioBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DoLogin(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody] RequestDoLoginJson request)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("business")]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DoLoginBusiness(
            [FromServices] IDoLoginBusinessUseCase useCase,
            [FromBody] RequestDoLoginBusinessJson request)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
