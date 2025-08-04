using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.User.Create;

namespace GerencieSeuNegocio.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }
        private void RequestToDomain()
        {
            CreateMap<RequestCreateUserJson, Domain.Entities.User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
