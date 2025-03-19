using AutoMapper;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Recipes.Update;

public class UpdateRecipeUseCase : IUpdateRecipeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateRecipeUseCase(IMapper mapper, IUnityOfWork unityOfWork)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
    }
    public async Task Execute(long id, RequestRecipeJson request)
    {
        Validate(request);

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

