using GerencieSeuNegocio.Domain.Entities;
using GerencieSeuNegocio.Domain.Security.Tokens;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GerencieSeuNegocio.Infraestructure.Services.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;
        public LoggedUser(GerencieSeuNegocioDbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }
        public async Task<User> User()
        {
            var token = _tokenProvider.Value();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

            var uuid = Guid.Parse(identifier);

            return await _dbContext.Users
                .AsNoTracking()
                .FirstAsync(u => u.Active && u.Uuid == uuid);
        }
    }
}
