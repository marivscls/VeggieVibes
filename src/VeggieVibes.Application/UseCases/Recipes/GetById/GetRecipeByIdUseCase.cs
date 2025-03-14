using VeggieVibes.Domain.Repositories;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Exception.ExceptionsBase;
using AutoMapper;
using VeggieVibes.Exception;

namespace VeggieVibes.Application.UseCases.Recipes.GetById;

public class GetRecipeByIdUseCase : IGetRecipeByIdUseCase
{
    private readonly IRecipesReadOnlyRepository _recipeReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetRecipeByIdUseCase(IRecipesReadOnlyRepository recipesReadOnlyRepository, IMapper mapper)
    {
        _recipeReadOnlyRepository = recipesReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<ResponseGetRecipeByIdJson> Execute(long id)
    {
        var recipe = await _recipeReadOnlyRepository.GetById(id);

        if (recipe is null)
        {
            throw new NotFoundException(ResourceErrorMessages.RECIPE_NOT_FOUND);
        }

        return _mapper.Map<ResponseGetRecipeByIdJson>(recipe);
    }
}