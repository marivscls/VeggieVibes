using VeggieVibes.Communication.Responses.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.GetAll;

public interface IGetAllRecipesUseCase
{
    Task<ResponseRecipesJson> Execute();
}