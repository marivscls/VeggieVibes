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

    public async Task<Recipe?> GetById(long id)
    {
        return await _DbContext.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id) ?? throw new KeyNotFoundException($"Recipe with id {id} not found.");
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

    public async Task Add(Recipe recipe)
    {
        await _DbContext.AddAsync(recipe);
    }

    public async Task Save(Recipe recipe)
    {
        _DbContext.Set<Recipe>().Add(recipe);
        await _DbContext.SaveChangesAsync();
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _DbContext.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == id);

        if (result == null)
            return false;

        _DbContext.Recipes.Remove(result);

        return true;
    }
}