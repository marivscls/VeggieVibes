using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories
{
    public interface IRecipesWriteOnlyRepository
    {
        Task Add(Recipe recipe);
    }
}
