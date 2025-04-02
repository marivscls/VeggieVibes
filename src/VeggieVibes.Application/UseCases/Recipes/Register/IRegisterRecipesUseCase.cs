using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases.Recipes.Register;

public interface IRegisterRecipesUseCase
{
    Task<ResponseRecipeJson> Execute(RequestRecipeJson request);
}
