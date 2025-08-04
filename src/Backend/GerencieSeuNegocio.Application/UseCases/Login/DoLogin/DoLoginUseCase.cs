using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Communication.Requests.User.Login;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly PasswordEncripter _passwordEncripter;

        public DoLoginUseCase(IUserReadOnlyRepository userReadOnlyRepository, PasswordEncripter passwordEncripter)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseCreateUserJson> Execute(RequestLoginJson request)
        {
            var passwordEncrypted = _passwordEncripter.Encrypt(request.Password);

            var user = await _userReadOnlyRepository.GetByEmailAndPassword(request.Email, passwordEncrypted) ?? throw new InvalidLoginException();

            return new ResponseCreateUserJson
            {
                Name = user.Name
            };
        }
    }
}
