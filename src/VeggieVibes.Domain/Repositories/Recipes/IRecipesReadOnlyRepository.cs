using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories.Recipes
{
    public interface IRecipesReadOnlyRepository
    {
        Task<Recipe?> GetById(long id);
        Task<List<Recipe>> GetAll();
        Task Save(Recipe recipe);
    }
}
