using GerencieSeuNegocio.Communication.Responses.User.Profile;

namespace GerencieSeuNegocio.Application.UseCases.User.Profile
{
    public interface IGetUserProfileUseCase
    {
        public Task<ResponseUserProfileJson> Execute();
    }
}
