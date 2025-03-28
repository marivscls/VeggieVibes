using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using AutoMapper;
using VeggieVibes.Exception.ExceptionsBase;
using VeggieVibes.Domain.Repositories.Recipes;

namespace VeggieVibes.Application.UseCases.Recipes.Register;

public class RegisterRecipesUseCase : IRegisteredRecipesUseCase
{
    private readonly IRecipesWriteOnlyRepository _recipesWriteRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterRecipesUseCase(IRecipesWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _recipesWriteRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRecipeJson> Execute(RequestRecipeJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Recipe>(request);

        await _recipesWriteRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRecipeJson>(entity);
    }

    private void Validate(RequestRecipeJson request)
    {
        var validator = new RecipeValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
