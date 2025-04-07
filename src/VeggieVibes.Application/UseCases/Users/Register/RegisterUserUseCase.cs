using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Communication.Responses.Users;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Repositories;
using AutoMapper;
using VeggieVibes.Exception.ExceptionsBase;
using VeggieVibes.Domain.Repositories.Users;

namespace VeggieVibes.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IRegisterUserWriteOnlyRepository _registerWriteRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IRegisterUserWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _registerWriteRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseUserJson> Execute(RequestRegisterUserJson request)
    {
        //Validate(request);

        var entity = _mapper.Map<User>(request);

        await _registerWriteRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseUserJson>(entity);
    }

    //private void Validate(RequestUserJson request)
    //{
    //    //var validator = new RecipeValidator();

    //    //var result = validator.Validate(request);

    //    if (!result.IsValid)
    //    {
    //        var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
    //        throw new ErrorOnValidationException(errorMessages);
    //    }
    //}
}
