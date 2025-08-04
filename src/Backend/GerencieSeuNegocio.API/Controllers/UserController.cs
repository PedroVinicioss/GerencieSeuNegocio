using GerencieSeuNegocio.Application.UseCases.User.Create;
using GerencieSeuNegocio.Application.UseCases.User.Update;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class UserController : GerencieSeuNegocioBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] RequestCreateUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateUserUseCase useCase,
            [FromBody] RequestUpdateUserJson request)
        {
            await useCase.Execute(request);
            return NoContent();
        }
    }
}
