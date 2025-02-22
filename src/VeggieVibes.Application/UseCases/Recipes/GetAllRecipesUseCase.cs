using AutoMapper;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Application.UseCases.Recipes;

public class GetAllRecipesUseCase : IGetAllRecipesUseCase
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetAllRecipesUseCase(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }
    public async Task<ResponseRecipesJson> Execute()
    {
        var recipes = await _recipeRepository.GetAll();

        return new ResponseRecipesJson
        {
            Recipes = _mapper.Map<List<ResponseShortRecipeJson>>(recipes)
        };
    }
}