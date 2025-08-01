using AutoMapper;
using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Communication.Requests.User.Register;
using GerencieSeuNegocio.Communication.Responses.User.Register;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        //private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        //private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        //IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(
            //IUserWriteOnlyRepository userWriteOnlyRepository,
            //IUserReadOnlyRepository userReadOnlyRepository,
            //IUnitOfWork unitOfWork,
            IMapper mapper,
            PasswordEncripter passwordEncripter)
        {
            //_userWriteOnlyRepository = userWriteOnlyRepository;
            //_userReadOnlyRepository = userReadOnlyRepository;
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validade(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            //await _userWriteOnlyRepository.Add(user);
            //await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.Name
            };
        }

        private async Task Validade(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            //var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
            var emailExist = false; // Simulating email existence check

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
