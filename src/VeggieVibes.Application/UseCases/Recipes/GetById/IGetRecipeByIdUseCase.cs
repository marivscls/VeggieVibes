using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases.Recipes.GetById;

public interface IGetRecipeByIdUseCase
{
    Task<ResponseGetRecipeByIdJson> Execute(long id);
}