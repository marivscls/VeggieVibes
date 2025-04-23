using AutoMapper;
using FluentValidation.Results;
using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Communication.Responses.Users;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Users;
using VeggieVibes.Domain.Security.Cryptography;
using VeggieVibes.Domain.Security.Tokens;
using VeggieVibes.Exception;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _tokenGenerator;
    public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IUnityOfWork unityOfWork, IMapper mapper, IPasswordEncripter passwordEncripter, IAccessTokenGenerator tokenGenerator)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserIdentifier = Guid.NewGuid();

        await _userWriteOnlyRepository.Add(user);  

        await _unityOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if(emailExist)
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));

        if (!result.IsValid)
        {
            var errormessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errormessages);
        }
    }
}
