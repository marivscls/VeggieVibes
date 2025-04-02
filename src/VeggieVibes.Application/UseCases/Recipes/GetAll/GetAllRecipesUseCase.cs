using AutoMapper;
using VeggieVibes.Communication.Responses.Recipes;
using VeggieVibes.Domain.Repositories.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.GetAll;

public class GetAllRecipesUseCase : IGetAllRecipesUseCase
{
    private readonly IRecipesReadOnlyRepository _recipesReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetAllRecipesUseCase(IRecipesReadOnlyRepository recipeReadOnlyRepository, IMapper mapper)
    {
        _recipesReadOnlyRepository = recipeReadOnlyRepository;
        _mapper = mapper;
    }
    public async Task<ResponseRecipesJson> Execute()
    {
        var recipes = await _recipesReadOnlyRepository.GetAll();

        return new ResponseRecipesJson
        {
            Recipes = _mapper.Map<List<ResponseShortRecipeJson>>(recipes)
        };
    }
}