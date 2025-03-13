using CommonTestUtilities.Requests;
using FluentAssertions;
using VeggieVibes.Application.UseCases.Recipes.Register;
using VeggieVibes.Exception;

namespace Validators.Test.Recipes.Register
{
    public class RegisterRecipeValidatorTests
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterRecipeValidator();

            var request = RequestRegisterRecipesJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Title_Empty()
        {
            var validator = new RegisterRecipeValidator();
            var resquest = RequestRegisterRecipesJsonBuilder.Build();
            resquest.Title = string.Empty;

            var result = validator.Validate(resquest);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));        }
    }
}
