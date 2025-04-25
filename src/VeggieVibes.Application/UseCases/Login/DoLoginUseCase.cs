using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses.Users;
using VeggieVibes.Domain.Repositories.Users;
using VeggieVibes.Domain.Security.Cryptography;
using VeggieVibes.Domain.Security.Tokens;

namespace VeggieVibes.Application.UseCases.Login;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(IUserReadOnlyRepository repository, IPasswordEncripter passwordEncripter, IAccessTokenGenerator accessTokenGenerator)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _repository = repository;
        _passwordEncripter = passwordEncripter;
    }
    public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        
        return new ResponseRegisteredUserJson
        {
            
        };
    }
}


