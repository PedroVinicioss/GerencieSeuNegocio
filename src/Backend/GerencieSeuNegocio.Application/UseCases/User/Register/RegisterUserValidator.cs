using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.User.Register;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);

            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_INVALID);
        }
    }
}
