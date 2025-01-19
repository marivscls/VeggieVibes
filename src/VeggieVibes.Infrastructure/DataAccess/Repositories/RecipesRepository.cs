using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Infrastructure.DataAccess.Repositories;

internal class RecipesRepository : IRecipesRepository
{
    private readonly VeggieVibesDbContext _DbContext;

    public RecipesRepository(VeggieVibesDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task Add(Recipe recipe)
    {
        await _DbContext.Recipes.AddAsync(recipe);
    }
}
