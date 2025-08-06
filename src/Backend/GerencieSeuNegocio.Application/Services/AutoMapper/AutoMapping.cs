using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Communication.Responses.User.Profile;
using GerencieSeuNegocio.Domain.Entities;

namespace GerencieSeuNegocio.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }
        private void RequestToDomain()
        {
            CreateMap<RequestCreateUserJson, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<RequestUpdateUserJson, User>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }

        private void DomainToResponse()
        {
            CreateMap<User, ResponseUserProfileJson>();
        }
    }
}
