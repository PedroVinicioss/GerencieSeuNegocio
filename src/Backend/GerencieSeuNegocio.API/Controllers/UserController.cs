using GerencieSeuNegocio.Application.UseCases.User.Register;
using GerencieSeuNegocio.Communication.Requests.User.Register;
using GerencieSeuNegocio.Communication.Responses.User.Register;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class UserController : GerencieSeuNegocioBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
