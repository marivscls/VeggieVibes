using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories;

public interface IRecipeRepository
{
    Task<Recipe> GetById(long id);
    Task Save(Recipe recipe);
}