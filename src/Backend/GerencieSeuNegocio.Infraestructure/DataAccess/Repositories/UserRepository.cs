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

        public async Task Add(User user, CancellationToken cancellationToken) => await _dbContext.Users.AddAsync(user, cancellationToken);
        public async Task<User> GetByUuid(Guid uuid, CancellationToken cancellationToken) => await _dbContext.Users.FirstAsync(u => u.Uuid.Equals(uuid) && u.Active, cancellationToken);
        public void Update(User user) => _dbContext.Users.Update(user);

        #endregion

        #region Read Operations

        public async Task<bool> ExistActiveUserWithEmail(string email, CancellationToken cancellationToken) => await _dbContext.Users.AnyAsync(u => u.Email.Equals(email) && u.Active, cancellationToken);
        public async Task<bool> ExistActiveUserWithUuid(Guid uuid, CancellationToken cancellationToken) => await _dbContext.Users.AnyAsync(u => u.Uuid.Equals(uuid) && u.Active, cancellationToken);
        public async Task<User?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password) && u.Active, cancellationToken);
        }
        public async Task<bool> ExistActiveBusinessOfUser(Guid userUuid, Guid businessUuid, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Businesses)
                .AnyAsync(u => u.Uuid.Equals(userUuid) && u.Active && u.Businesses.Any(b => b.Uuid.Equals(businessUuid) && b.Active), cancellationToken);
        }

        #endregion
    }
}
