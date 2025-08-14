using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.Business.Create;
using GerencieSeuNegocio.Communication.Responses.Business.Create;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.Business;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;

namespace GerencieSeuNegocio.Application.UseCases.Business.Create
{
    public class CreateBusinessUseCase : ICreateBusinessUseCase
    {
        private readonly IBusinessWriteOnlyRepository _businessWriteOnlyRepository;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBusinessUseCase(
            IBusinessWriteOnlyRepository businessWriteOnlyRepository,
            ILoggedUser loggedUser,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _businessWriteOnlyRepository = businessWriteOnlyRepository;
            _loggedUser = loggedUser;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseCreateBusinessJson> Execute(RequestCreateBusinessJson request, CancellationToken cancellationToken = default)
        {
            await Validate(request, cancellationToken);

            var loggedUser = await _loggedUser.User(cancellationToken);

            var business = _mapper.Map<Domain.Entities.Business>(request);
            business.UserId = loggedUser.Id;

            await _businessWriteOnlyRepository.Add(business, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<ResponseCreateBusinessJson>(business);
        }

        private async Task Validate(RequestCreateBusinessJson request, CancellationToken cancellationToken = default)
        {
            var validator = new CreateBusinessValidator();

            var result = await validator.ValidateAsync(request, cancellationToken);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
