using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        public string Generate(Guid userIdentifier, RoleType role);    
    }
}
