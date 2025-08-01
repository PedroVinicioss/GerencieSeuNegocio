using GerencieSeuNegocio.Domain.Entities;
using GerencieSeuNegocio.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace GerencieSeuNegocio.Infraestructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;
        public UserRepository(GerencieSeuNegocioDbContext dbContext) => _dbContext = dbContext;
        public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
    }
}
