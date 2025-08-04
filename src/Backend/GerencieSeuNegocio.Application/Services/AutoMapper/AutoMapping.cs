using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Requests.User.Update;

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

            CreateMap<RequestUpdateUserJson, Domain.Entities.User>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
