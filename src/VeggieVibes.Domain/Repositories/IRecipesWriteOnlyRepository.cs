using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories
{
    public interface IRecipesWriteOnlyRepository
    {
        public Task Add(Recipe recipe);
    }
}
