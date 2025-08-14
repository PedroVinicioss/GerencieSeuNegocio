using AutoMapper;
using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Responses.Token;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Domain.Security.Tokens;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.User.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly PasswordEncripter _passwordEncripter;

        public CreateUserUseCase(
            IAccessTokenGenerator accessTokenGenerator,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            PasswordEncripter passwordEncripter)
        {
            _accessTokenGenerator = accessTokenGenerator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request, CancellationToken cancellationToken = default)
        {
            await Validade(request, cancellationToken);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return new ResponseCreateUserJson
            {
                Name = user.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = _accessTokenGenerator.Generate(user.Uuid)
                },
            };
        }

        private async Task Validade(RequestCreateUserJson request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserValidator();

            var result = await validator.ValidateAsync(request, cancellationToken);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email, cancellationToken);

            if (emailExist)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_EXIST));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
