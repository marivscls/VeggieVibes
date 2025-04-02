using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Communication.Responses.Users;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using AutoMapper;
using VeggieVibes.Exception.ExceptionsBase;
using VeggieVibes.Domain.Repositories.Recipes;

namespace VeggieVibes.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IRecipesWriteOnlyRepository _recipesWriteRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IRecipesWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _recipesWriteRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Recipe>(request);

        await _recipesWriteRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseUserJson>(entity);
    }

    private void Validate(RequestUserJson request)
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
