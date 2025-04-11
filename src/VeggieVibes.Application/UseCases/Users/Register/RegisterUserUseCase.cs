using AutoMapper;
using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Communication.Responses.Users;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Users;
using VeggieVibes.Domain.Security.Cryptography;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IRegisterUserWriteOnlyRepository _registerWriteRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    public RegisterUserUseCase(IRegisterUserWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper, IPasswordEncripter passwordEncripter)
    {
        _registerWriteRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<ResponseUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);

        return new ResponseUserJson
        {
            Name = user.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errormessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errormessages);
        }
    }
}
