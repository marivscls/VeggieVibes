namespace VeggieVibes.Application.UseCases.Recipes.Delete;

public interface IDeleteRecipeUseCase
{
    Task<bool> Execute(long id);
}
