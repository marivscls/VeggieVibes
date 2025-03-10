using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories;

public interface IRecipesRepository
{
    public Task Add(Recipe recipe);
    public Task Delete(long id);
    public Task<Recipe> Update(Recipe recipe);
}
