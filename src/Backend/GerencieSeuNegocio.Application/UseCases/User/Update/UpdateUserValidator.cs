using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.User.Update
{
    public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
    {
        public UpdateUserValidator() 
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.NAME_EMPTY);

            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.EMAIL_EMPTY);

            When(request => !string.IsNullOrWhiteSpace(request.Email), () =>
            {
               RuleFor(request => request.Email)
                    .EmailAddress()
                    .WithMessage(ResourceMessagesException.EMAIL_INVALID);
            });
        }
    }
}
