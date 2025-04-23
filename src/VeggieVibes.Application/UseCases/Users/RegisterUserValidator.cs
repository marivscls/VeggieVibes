using FluentValidation;
using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Exception;

namespace VeggieVibes.Application.UseCases.Users;

public class RegisterUserValidator : AbstractValidator<RequestRegisteredUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.USER_NAME_EMPTY);
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.USER_EMAIIL_EMPTY)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.USER_EMAIIL_INVALID);

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisteredUserJson>());
    }
}