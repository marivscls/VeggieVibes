using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Infrastructure.DataAccess.Repositories;
public class RecipesRepository : IRecipesWriteOnlyRepository, IRecipesReadOnlyRepository
{
    private readonly VeggieVibesDbContext _DbContext;

    public RecipesRepository(VeggieVibesDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task<Recipe> GetById(long id)
    {
        var recipe = await _DbContext.Recipes.FindAsync(id) ?? throw new KeyNotFoundException($"Recipe with id {id} not found.");
        return recipe;
    }

    public async Task<List<Recipe>> GetAll()
    {
        var recipes = await _DbContext.Recipes.AsNoTracking().ToListAsync();

        if (recipes.Count == 0)
        {
            throw new KeyNotFoundException("No recipes found.");
        }

        return recipes;
    }

    public async Task Save(Recipe recipe)
    {
        _DbContext.Set<Recipe>().Add(recipe);
        await _DbContext.SaveChangesAsync();
    }

    public async Task Add(Recipe recipe)
    {
        await _DbContext.AddAsync(recipe);
    }
}