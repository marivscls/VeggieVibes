using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories.Users;

namespace VeggieVibes.Infrastructure.DataAccess.Recipes;
public class UsersRepository : IRegisterUserWriteOnlyRepository
{
    private readonly VeggieVibesDbContext _DbContext;

    public UsersRepository(VeggieVibesDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _DbContext.AddAsync(user);
    }

    public async Task Save(User user)
    {
        _DbContext.Set<User>().Add(user);
        await _DbContext.SaveChangesAsync();
    }
}