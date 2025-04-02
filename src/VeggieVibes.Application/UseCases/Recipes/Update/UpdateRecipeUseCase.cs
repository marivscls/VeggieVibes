using AutoMapper;
using VeggieVibes.Communication.Requests.Recipes;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Recipes;
using VeggieVibes.Exception;
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
    public async Task Execute(long id, RequestUpdateRecipeJson request)
    {
        Validate(request);

        var recipe = await _repository.GetById(id);

        if (recipe is null)
        {
            throw new NotFoundException(ResourceErrorMessages.RECIPE_NOT_FOUND);
        }

        _mapper.Map(request, recipe);

        _repository.Update(recipe);

        await _unityOfWork.Commit();
    }

    private void Validate(RequestUpdateRecipeJson request)
    {
        var validator = new RecipeValidatorUpdate();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

