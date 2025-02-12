using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Infrastructure.DataAccess;

internal class UnityOfWork : IUnityOfWork
{
    private readonly VeggieVibesDbContext _veggieVibesDbContext;

    public UnityOfWork(VeggieVibesDbContext veggieVibesDbContext)
    {
        _veggieVibesDbContext = veggieVibesDbContext;
    }
    public async Task Commit() => await _veggieVibesDbContext.SaveChangesAsync();
}
