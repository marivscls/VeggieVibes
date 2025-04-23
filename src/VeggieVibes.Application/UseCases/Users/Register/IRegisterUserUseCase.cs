using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Communication.Responses.Users;

namespace VeggieVibes.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseUserJson> Execute(RequestRegisterUserJson request);
}
