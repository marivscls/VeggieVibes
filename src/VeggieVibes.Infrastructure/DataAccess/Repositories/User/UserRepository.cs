using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories.Users;

namespace VeggieVibes.Infrastructure.DataAccess.Recipes;
public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly VeggieVibesDbContext _dbContext;

    public UserRepository(VeggieVibesDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user)
    {
       await _dbContext.User.AddAsync(user);    
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.User.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.User
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email.Equals(email));   
    }
}