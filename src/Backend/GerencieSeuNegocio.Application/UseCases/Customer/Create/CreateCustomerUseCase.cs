using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.Customer.Create;
using GerencieSeuNegocio.Communication.Responses.Customer.Profile;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.Customer;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.Customer.Create
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository _customerWriteOnlyRepository;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerUseCase(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            ILoggedUser loggedUser,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _customerWriteOnlyRepository = customerWriteOnlyRepository;
            _loggedUser = loggedUser;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseCreateCustomerJson> Execute(RequestCreateCustomerJson request, CancellationToken cancellationToken = default)
        {
            await Validate(request, cancellationToken);

            var business = await _loggedUser.Business(cancellationToken);

            var customer = _mapper.Map<Domain.Entities.Customer>(request);
            customer.BusinessId = business.Id;

            await _customerWriteOnlyRepository.Add(customer, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<ResponseCreateCustomerJson>(customer);
        }

        private async Task Validate(RequestCreateCustomerJson request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerValidator();

            var result = await validator.ValidateAsync(request, cancellationToken);

            var business = await _loggedUser.Business(cancellationToken);

            var existingCustomerWithDocument = await _customerReadOnlyRepository.GetByDocument(request.Document, business.Id, cancellationToken);

            if (existingCustomerWithDocument != null)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Document), ResourceMessagesException.CUSTOMER_DOCUMENT_ALREADY_EXIST));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
