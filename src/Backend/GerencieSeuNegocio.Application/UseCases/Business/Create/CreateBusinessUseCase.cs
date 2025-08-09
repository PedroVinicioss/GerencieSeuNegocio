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
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessWriteOnlyRepository _businessWriteOnlyRepository;
        public CreateBusinessUseCase(ILoggedUser loggedUser, IMapper mapper, IUnitOfWork unitOfWork, IBusinessWriteOnlyRepository businessWriteOnlyRepository)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _businessWriteOnlyRepository = businessWriteOnlyRepository;
        }
        public async Task<ResponseCreateBusinessJson> Execute(RequestCreateBusinessJson request)
        {
            await Validate(request);

            var loggedUser = await _loggedUser.User();

            var business = _mapper.Map<Domain.Entities.Business>(request);
            business.UserId = loggedUser.Id;

            await _businessWriteOnlyRepository.Add(business);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCreateBusinessJson>(business);
        }

        private async Task Validate(RequestCreateBusinessJson request)
        {
            var validator = new CreateBusinessValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
