using AutoMapper;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Recipes;
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
            return false;

        await _unityOfWork.Commit();
        return true;

    }
}
