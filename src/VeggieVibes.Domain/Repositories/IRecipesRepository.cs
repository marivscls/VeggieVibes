using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories;

public interface IRecipesRepository
{
    public Task Add(Recipe recipe);
}
