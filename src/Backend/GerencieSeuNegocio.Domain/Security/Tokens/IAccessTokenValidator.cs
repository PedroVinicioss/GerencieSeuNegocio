namespace GerencieSeuNegocio.Domain.Security.Tokens
{
    public interface IAccessTokenValidator
    {
        public Guid ValidateAndGetUserUuid(string token);
    }
}
