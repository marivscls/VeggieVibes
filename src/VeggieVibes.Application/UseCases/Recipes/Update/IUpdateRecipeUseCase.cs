using VeggieVibes.Communication.Requests;

namespace VeggieVibes.Application.UseCases.Recipes.Update;

public interface IUpdateRecipeUseCase
{
    Task Execute(long id, RequestRecipeJson request);
}
