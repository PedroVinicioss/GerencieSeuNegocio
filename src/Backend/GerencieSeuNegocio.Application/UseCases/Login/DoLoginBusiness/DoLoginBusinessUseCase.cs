using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.Login.DoLoginBusiness;
using GerencieSeuNegocio.Communication.Responses.Token;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using GerencieSeuNegocio.Domain.Security.Tokens;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.Login.DoLoginBusiness
{
    public class DoLoginBusinessUseCase : IDoLoginBusinessUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        public DoLoginBusinessUseCase(
            ILoggedUser loggedUser,
            IMapper mapper,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseCreateUserJson> Execute(RequestDoLoginBusinessJson request, CancellationToken cancellationToken = default)
        {
            await Validate(request, cancellationToken);

            var loggedUser = await _loggedUser.User();

            return new ResponseCreateUserJson
            {
                Name = loggedUser.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = _accessTokenGenerator.GenerateWithBusiness(loggedUser.Uuid, request.BusinessUuid),
                },
            };
        }

        private async Task Validate(RequestDoLoginBusinessJson request, CancellationToken cancellationToken)
        {
            var validator = new DoLoginBusinessValidator();
            var result = await validator.ValidateAsync(request, cancellationToken);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
