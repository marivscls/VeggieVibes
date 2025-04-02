using VeggieVibes.Communication.Requests.Recipes;
using VeggieVibes.Communication.Responses.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.Register;

public interface IRegisterRecipesUseCase
{
    Task<ResponseRecipeJson> Execute(RequestRecipeJson request);
}
