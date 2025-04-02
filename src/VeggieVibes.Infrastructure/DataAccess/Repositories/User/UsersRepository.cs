using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories.Recipes;

namespace VeggieVibes.Infrastructure.DataAccess.Recipes;
public class UsersRepository : IRecipesWriteOnlyRepository, IRecipesReadOnlyRepository, IRecipesUpdateOnlyRepository
{
    private readonly VeggieVibesDbContext _DbContext;

    public UsersRepository(VeggieVibesDbContext dbContext)
    {
        _DbContext = dbContext;
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

    async Task<Recipe?> IRecipesReadOnlyRepository.GetById(long id)
    {
        return await _DbContext.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    async Task<Recipe?> IRecipesUpdateOnlyRepository.GetById(long id)
    {
        return await _DbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
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

        if (result is null)
            return false;

        _DbContext.Recipes.Remove(result);

        return true;
    }

    public void Update(Recipe recipe)
    {
        _DbContext.Recipes.Update(recipe);
    }
}