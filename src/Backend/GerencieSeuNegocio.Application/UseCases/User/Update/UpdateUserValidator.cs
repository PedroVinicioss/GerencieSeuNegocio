using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.User.Update
{
    public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
    {
        public UpdateUserValidator() 
        { 
            When(request => !string.IsNullOrWhiteSpace(request.Email), () =>
            {
               RuleFor(request => request.Email)
                    .EmailAddress()
                    .WithMessage(ResourceMessagesException.EMAIL_INVALID);
            });
        }
    }
}
