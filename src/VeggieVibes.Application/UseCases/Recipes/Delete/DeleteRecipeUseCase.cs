using VeggieVibes.Domain.Repositories;
using VeggieVibes.Exception;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Recipes.Delete;
public class DeleteRecipeUseCase : IDeleteRecipeUseCase
{
    private readonly IRecipesWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteRecipeUseCase(IRecipesWriteOnlyRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    public async Task<bool> Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (!result)
        {
            throw new NotFoundException(ResourceErrorMessages.RECIPE_NOT_FOUND);
        }

        await _unityOfWork.Commit();
        return true;
    }
}
