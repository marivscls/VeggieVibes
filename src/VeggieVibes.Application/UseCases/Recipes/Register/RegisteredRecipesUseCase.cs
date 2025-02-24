using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using AutoMapper;
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

    public async Task<ResponseRegisteredRecipesJson> Execute(RequestRegisterRecipesJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Recipe>(request);

        await _recipesWriteRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredRecipesJson>(entity);
    }

    private void Validate(RequestRegisterRecipesJson request)
    {
        var validator = new RegisteredRecipesValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
