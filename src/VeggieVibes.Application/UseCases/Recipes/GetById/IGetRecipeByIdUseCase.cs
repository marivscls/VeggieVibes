using VeggieVibes.Communication.Responses.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.GetById;

public interface IGetRecipeByIdUseCase
{
    Task<ResponseGetRecipeByIdJson> Execute(long id);
}