using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses.Users;

namespace VeggieVibes.Application.UseCases.Login;

public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}

