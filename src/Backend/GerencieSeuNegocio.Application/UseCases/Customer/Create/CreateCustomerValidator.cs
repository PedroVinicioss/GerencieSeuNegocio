using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.Customer.Create;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.Customer.Create
{
    public class CreateCustomerValidator : AbstractValidator<RequestCreateCustomerJson>
    {
        public CreateCustomerValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            
            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(customer => customer.Phone)
                .NotEmpty().WithMessage(ResourceMessagesException.PHONE_EMPTY)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage(ResourceMessagesException.PHONE_INVALID);

            RuleFor(customer => customer.Document)
                .NotEmpty().WithMessage(ResourceMessagesException.DOCUMENT_EMPTY)
                .Matches(@"^\d{11}$").WithMessage(ResourceMessagesException.DOCUMENT_INVALID);
        }
    }
}
