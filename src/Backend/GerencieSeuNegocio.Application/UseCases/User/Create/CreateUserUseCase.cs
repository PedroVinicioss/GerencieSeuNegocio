using AutoMapper;
using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Responses.User.Create;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.User.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public CreateUserUseCase(
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            PasswordEncripter passwordEncripter)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request)
        {
            await Validade(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseCreateUserJson
            {
                Name = request.Name
            };
        }

        private async Task Validade(RequestCreateUserJson request)
        {
            var validator = new CreateUserValidator();

            var result = validator.Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

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
