using FluentValidation;
using GerencieSeuNegocio.Communication.Requests.Business.Create;
using GerencieSeuNegocio.Domain.Enums;
using GerencieSeuNegocio.Exceptions;

namespace GerencieSeuNegocio.Application.UseCases.Business.Create
{
    public class CreateBusinessValidator : AbstractValidator<RequestCreateBusinessJson>
    {
        public CreateBusinessValidator() 
        {
            RuleFor(business => business.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);

            RuleFor(b => b.Type).NotEmpty().WithMessage(ResourceMessagesException.BUSINESS_TYPE_EMPTY)

                .Must(v => Enum.TryParse<BusinessType>(v, true, out var parsed) && parsed != BusinessType.Undefined)
                    .WithMessage(ResourceMessagesException.BUSINESS_TYPE_INVALID);
        }
    }
}
