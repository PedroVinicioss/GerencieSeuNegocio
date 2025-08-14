namespace GerencieSeuNegocio.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        public string Generate(Guid userIdentifier);
        public string GenerateWithBusiness(Guid userIdentifier, Guid businessIdentifier);
    }
}
