using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases;

public interface IRegisterRecipesUseCase
{
    Task<ResponseRegisterRecipesJson> Execute(RequestRegisterRecipesJson request);
}
