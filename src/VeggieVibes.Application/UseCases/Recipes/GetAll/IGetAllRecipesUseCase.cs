using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases.Recipes.GetAll;

public interface IGetAllRecipesUseCase
{
    Task<ResponseRecipesJson> Execute();
}