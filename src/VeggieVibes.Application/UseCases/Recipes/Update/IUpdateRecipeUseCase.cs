using VeggieVibes.Communication.Requests.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.Update;

public interface IUpdateRecipeUseCase
{
    Task Execute(long id, RequestUpdateRecipeJson request);
}
