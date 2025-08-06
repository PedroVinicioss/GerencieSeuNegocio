using GerencieSeuNegocio.Domain.Entities;
using GerencieSeuNegocio.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace GerencieSeuNegocio.Infraestructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
    {
        private readonly GerencieSeuNegocioDbContext _dbContext;
        public UserRepository(GerencieSeuNegocioDbContext dbContext) => _dbContext = dbContext;

        #region Write Operations

        public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
        public void Update(User user) => _dbContext.Users.Update(user);

        #endregion

        #region Read Operations

        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
        public async Task<bool> ExistActiveUserWithUuid(Guid uuid) => await _dbContext.Users.AnyAsync(u => u.Uuid.Equals(uuid) && u.Active);
        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password) && u.Active);
        }

        #endregion
    }
}
