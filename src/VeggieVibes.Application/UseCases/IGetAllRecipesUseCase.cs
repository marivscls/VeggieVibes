using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases;

public interface IGetAllRecipesUseCase
{
    Task<ResponseRecipesJson> Execute();
}