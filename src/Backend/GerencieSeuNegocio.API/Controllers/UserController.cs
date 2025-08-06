using GerencieSeuNegocio.API.Attributes;
using GerencieSeuNegocio.Application.UseCases.User.Create;
using GerencieSeuNegocio.Application.UseCases.User.Profile;
using GerencieSeuNegocio.Application.UseCases.User.Update;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using GerencieSeuNegocio.Communication.Responses.User.Profile;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Controllers
{
    public class UserController : GerencieSeuNegocioBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
        [AuthenticatedUser]
        public async Task<IActionResult> GetUserProfile(
        [FromServices] IGetUserProfileUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] RequestCreateUserJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [AuthenticatedUser]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateUserUseCase useCase,
            [FromBody] RequestUpdateUserJson request)
        {
            await useCase.Execute(request);
            return NoContent();
        }
    }
}
