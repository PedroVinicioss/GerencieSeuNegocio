using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Execute(RequestUpdateUserJson request)
        {
            await Validade(request);

            var user = await _userReadOnlyRepository.GetByIdAsync(1); 
            _mapper.Map(request, user);

            _userUpdateOnlyRepository.Update(user);
            await _unitOfWork.Commit();
        }

        private async Task Validade(RequestUpdateUserJson request)
        {
            var validator = new UpdateUserValidator();
            var result = validator.Validate(request);

            await ValidateEmail(request, result);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

        private async Task ValidateEmail(RequestUpdateUserJson request, FluentValidation.Results.ValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(request.Email)) return;

            if (await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email))
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Email), ResourceMessagesException.EMAIL_ALREADY_EXIST));
        }
    }
}
