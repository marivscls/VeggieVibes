using AutoMapper;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Repositories;

namespace VeggieVibes.Application.UseCases.Recipes;

public class GetAllRecipesUseCase : IGetAllRecipesUseCase
{
    private readonly IRecipesReadOnlyRepository _recipesReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetAllRecipesUseCase(IRecipesReadOnlyRepository recipesReadOnlyRepository, IMapper mapper)
    {
        _recipesReadOnlyRepository = recipesReadOnlyRepository;
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