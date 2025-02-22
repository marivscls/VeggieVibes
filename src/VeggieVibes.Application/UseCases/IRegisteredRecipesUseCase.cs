using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases;

public interface IRegisteredRecipesUseCase
{
    Task<ResponseRegisteredRecipesJson> Execute(RequestRegisterRecipesJson request);
}
