using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories.Recipes
{
    public interface IRecipesUpdateOnlyRepository
    {
        Task<Recipe?> GetById(long id);
        void Update(Recipe recipe);
    }
}
