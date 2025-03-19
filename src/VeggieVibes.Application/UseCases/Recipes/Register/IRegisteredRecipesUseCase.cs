using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases.Recipes.Register;

public interface IRegisteredRecipesUseCase
{
    Task<ResponseRegisterRecipesJson> Execute(RequestRecipeJson request);
}
