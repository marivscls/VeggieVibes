using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Infrastructure.DataAccess.Repositories;
public class RecipeRepository : IRecipeRepository
{
    private readonly VeggieVibesDbContext _DbContext;

    public RecipeRepository(VeggieVibesDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task<Recipe> GetById(long id)
    {
        var recipe = await _DbContext.Recipes.FindAsync(id) ?? throw new KeyNotFoundException($"Recipe with id {id} not found.");
        return recipe;
    }

    public async Task Save(Recipe recipe)
    {
        _DbContext.Set<Recipe>().Add(recipe);
        await _DbContext.SaveChangesAsync();
    }

}