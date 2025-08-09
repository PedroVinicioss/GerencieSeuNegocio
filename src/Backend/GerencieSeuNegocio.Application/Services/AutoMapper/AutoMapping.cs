using AutoMapper;
using GerencieSeuNegocio.Communication.Requests.Business.Create;
using GerencieSeuNegocio.Communication.Requests.User.Create;
using GerencieSeuNegocio.Communication.Requests.User.Update;
using GerencieSeuNegocio.Communication.Responses.Business.Create;
using GerencieSeuNegocio.Communication.Responses.User.Profile;
using GerencieSeuNegocio.Domain.Entities;
using GerencieSeuNegocio.Domain.Enums;

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

            CreateMap<RequestCreateBusinessJson, Business>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s =>
                    Enum.Parse<BusinessType>(s.Type, true)));
        }

        private void DomainToResponse()
        {
            CreateMap<User, ResponseUserProfileJson>();

            CreateMap<Business, ResponseCreateBusinessJson>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                    Enum.GetName(typeof(BusinessType), src.Type)));
        }
    }
}
