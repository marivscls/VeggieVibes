using FluentValidation;
using VeggieVibes.Communication.Requests.Recipes;
using VeggieVibes.Exception;

namespace VeggieVibes.Application.UseCases.Recipes;

public class RecipeValidator : AbstractValidator<RequestRecipeJson>
{
    public RecipeValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_REQUIRED)
            .MaximumLength(100)
            .WithMessage(ResourceErrorMessages.TITLE_MAX_LENGTH);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.DESCRIPTION_REQUIRED)
            .MaximumLength(500)
            .WithMessage(ResourceErrorMessages.DESCRIPTION_MAX_LENGTH);

        RuleFor(x => x.Ingredients)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.INGREDIENTS_REQUIRED);

        RuleFor(x => x.Instructions)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.INSTRUCTIONS_REQUIRED);

        RuleFor(x => x.PreparationTimeMinutes)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PREPARATION_TIME_POSITIVE);

        RuleFor(x => x.CookingTimeMinutes)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.COOKING_TIME_POSITIVE);

        RuleFor(x => x.CaloriesPerServing)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.CALORIES_POSITIVE);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.USER_ID_REQUIRED);
    }
}