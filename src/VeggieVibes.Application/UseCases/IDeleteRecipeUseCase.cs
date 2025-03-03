namespace VeggieVibes.Application.UseCases;

public interface IDeleteRecipeUseCase
{
    Task<bool> Execute(long id);
}
