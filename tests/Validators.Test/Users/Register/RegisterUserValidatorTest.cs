using CommonTestUtilities.Requests;
using FluentAssertions;
using VeggieVibes.Application.UseCases.Users;
using VeggieVibes.Exception;

namespace Validators.Test.Users.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Succes()
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Error_Name_Invalid(string name)
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
        }
    }
}
