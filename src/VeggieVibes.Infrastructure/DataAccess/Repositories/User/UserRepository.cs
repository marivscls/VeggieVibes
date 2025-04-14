using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Repositories.Users;

namespace VeggieVibes.Infrastructure.DataAccess.Recipes;
public class UserRepository : IUserReadOnlyRepository
{
    private readonly VeggieVibesDbContext _dbContext;

    public UserRepository(VeggieVibesDbContext dbContext) => _dbContext = dbContext;

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
      return await _dbContext.User.AnyAsync(x => x.Email.Equals(email));
    }
}