﻿using CommonTestUtilities.Requests;
using FluentAssertions;
using VeggieVibes.Application.UseCases.Recipes.Register;

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
    }
}
