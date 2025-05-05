using CommonTestUtilities.Requests;
using FluentAssertions;
using VeggieVibes.Application.UseCases.Recipes;
using VeggieVibes.Exception;

namespace Validators.Test.Recipes.Register
{
    public class RegisterRecipeValidatorTests
    {
        [Fact]
        public void Success()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            var result = validator.Validate(request);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title)
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Title = title;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.TITLE_REQUIRED);
        }

        [Fact]
        public void Error_Description_Empty()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Description = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.DESCRIPTION_REQUIRED);
        }

        [Fact]
        public void Error_Description_MaxLength()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Description = new string('A', 501);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.DESCRIPTION_MAX_LENGTH);
        }

        [Fact]
        public void Error_Calories_Negative()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.CaloriesPerServing = -10;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.CALORIES_POSITIVE);
        }

        [Fact]
        public void Error_PreparationTime_ZeroOrNegative()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.PreparationTimeMinutes = 0;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.PREPARATION_TIME_POSITIVE);
        }

        [Fact]
        public void Error_CookingTime_ZeroOrNegative()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.CookingTimeMinutes = -5;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.COOKING_TIME_POSITIVE);
        }

        [Fact]
        public void Error_Ingredients_Empty()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Ingredients.Clear();

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.INGREDIENTS_REQUIRED);
        }

        [Fact]
        public void Error_Instructions_Empty()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Instructions.Clear();

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.INSTRUCTIONS_REQUIRED);
        }

        [Fact]
        public void Error_Title_MaxLength()
        {
            var validator = new RecipeValidator();
            var request = RequestRegisterRecipesJsonBuilder.Build();
            request.Title = new string('B', 101);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be(ResourceErrorMessages.TITLE_MAX_LENGTH);
        }
    }
}
