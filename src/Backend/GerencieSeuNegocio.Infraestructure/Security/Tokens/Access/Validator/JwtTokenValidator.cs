using GerencieSeuNegocio.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GerencieSeuNegocio.Infraestructure.Security.Tokens.Access.Validator
{
    public class JwtTokenValidator : JwtTokenHandler, IAccessTokenValidator
    {
        private readonly string _signingKey;
        public JwtTokenValidator(string signingKey) => _signingKey = signingKey;

        public Guid ValidateAndGetUserUuid(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityKey(_signingKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero 
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            var userUuid = principal.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

            return Guid.Parse(userUuid);
        }
    }
}
