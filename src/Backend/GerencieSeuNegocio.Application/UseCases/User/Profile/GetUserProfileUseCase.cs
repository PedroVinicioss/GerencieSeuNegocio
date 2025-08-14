using AutoMapper;
using GerencieSeuNegocio.Communication.Responses.User.Profile;
using GerencieSeuNegocio.Domain.Services.LoggedUser;

namespace GerencieSeuNegocio.Application.UseCases.User.Profile
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;
        public GetUserProfileUseCase(ILoggedUser loggedUser, IMapper mapper)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
        }
        public async Task<ResponseUserProfileJson> Execute(CancellationToken cancellationToken)
        {
            var user = await _loggedUser.User(cancellationToken);

            return _mapper.Map<ResponseUserProfileJson>(user);
        }
    }
}
