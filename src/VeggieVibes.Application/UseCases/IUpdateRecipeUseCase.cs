using VeggieVibes.Communication.Requests;
using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Application.UseCases;

public interface IUpdateRecipeUseCase
{
    Task<RequestUpdateRecipeJson> Execute(long id);
}
