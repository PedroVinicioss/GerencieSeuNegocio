using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Domain.Extensions;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            ILoggedUser loggedUser,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserUpdateOnlyRepository userUpdateOnlyRepository)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
        }
        public async Task Execute(RequestUpdateUserJson request, CancellationToken cancellationToken = default)
        {
            var loggedUser = await _loggedUser.User();

            await Validade(request, loggedUser.Email, cancellationToken);

            var user = await _userUpdateOnlyRepository.GetByUuid(loggedUser.Uuid);
            
            _mapper.Map(request, user);

            _userUpdateOnlyRepository.Update(user);
            await _unitOfWork.Commit();
        }

        private async Task Validade(RequestUpdateUserJson request, string currentEmail, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserValidator();
            var result = await validator.ValidateAsync(request, cancellationToken);

            await ValidateEmail(request, result, currentEmail);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

        private async Task ValidateEmail(RequestUpdateUserJson request, FluentValidation.Results.ValidationResult result, string currentEmail)
        {
            if (currentEmail.Equals(request.Email).IsFalse())
            {
                var userExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
                if (userExist)
                    result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Email), ResourceMessagesException.EMAIL_ALREADY_EXIST));
            }
        }
    }
}
