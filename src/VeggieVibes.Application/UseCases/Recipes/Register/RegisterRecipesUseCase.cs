using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using AutoMapper;
namespace VeggieVibes.Application.UseCases.Recipes.Register;

public class RegisterRecipesUseCase : IRegisterRecipesUseCase
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterRecipesUseCase(IRecipesRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _recipesRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterRecipesJson> Execute(RequestRegisterRecipesJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Recipe>(request);

        await _recipesRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisterRecipesJson>(entity);
    }

    private void Validate(RequestRegisterRecipesJson request)
    {
        var validator = new RegisterRecipesValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
