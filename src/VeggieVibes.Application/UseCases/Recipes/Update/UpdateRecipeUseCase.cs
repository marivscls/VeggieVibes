using AutoMapper;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Recipes;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Recipes.Update;

public class UpdateRecipeUseCase : IUpdateRecipeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IRecipesUpdateOnlyRepository _repository;

    public UpdateRecipeUseCase(IMapper mapper, IUnityOfWork unityOfWork, IRecipesUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }
    public async Task Execute(long id, RequestRecipeJson request)
    {
        Validate(request);

        _repository.Update();

        await _unityOfWork.Commit();
    }

    private void Validate(RequestRecipeJson request)
    {
        var validator = new RecipeValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

