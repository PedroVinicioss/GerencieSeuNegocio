using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.Login.DoLoginBusiness;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.Login.DoLoginBusiness
{
    public class DoLoginBusinessValidator : AbstractValidator<RequestDoLoginBusinessJson>
    {
        public DoLoginBusinessValidator()
        {
            RuleFor(x => x.BusinessUuid)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.BUSINESS_EMPTY);
        }
    }
}