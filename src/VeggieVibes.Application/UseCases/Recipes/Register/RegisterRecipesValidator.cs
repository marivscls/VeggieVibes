using FluentValidation;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Application.UseCases.Recipes.Register;

public class RegisterRecipesValidator : AbstractValidator<RequestRegisterRecipesJson>
{
    public RegisterRecipesValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("The title is required");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The description is required");

        RuleFor(x => x.Category)
            .IsInEnum().WithMessage("The category is invalid. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(RecipeCategory))));

        RuleFor(x => x.Difficulty)
            .IsInEnum().WithMessage("The difficulty is invalid. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(RecipeDifficulty))));

        RuleFor(x => x.MealType)
            .IsInEnum().WithMessage("Invalid meal type. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(MealType))));

        RuleFor(x => x.Origin)
            .IsInEnum().WithMessage("Invalid culinary origin. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(CulinaryOrigin))));

        RuleFor(x => x.DietType)
            .IsInEnum().WithMessage("The diet type is invalid. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(DietType))));

        RuleFor(x => x.Allergen)
             .IsInEnum().WithMessage("The allergen is invalid. Valid values are: " + string.Join(", ", Enum.GetNames(typeof(Allergen))));

        RuleFor(x => x.Instructions)
            .NotNull().WithMessage("The recipe must include at least one instruction")
            .NotEmpty().WithMessage("The recipe must include at least one instruction")
            .ForEach(instruction => instruction
                .NotEmpty().WithMessage("An instruction cannot be empty"));

        RuleFor(x => x.PreparationTimeMinutes)
            .GreaterThan(0).WithMessage("Preparation time must be greater than zero");

        RuleFor(x => x.CookingTimeMinutes)
            .GreaterThanOrEqualTo(0).WithMessage("Cooking time cannot be negative");

        RuleFor(x => x)
            .Must(request => request.PreparationTimeMinutes + request.CookingTimeMinutes > 0)
            .WithMessage("The total time (preparation + cooking) must be greater than zero");

        RuleFor(x => x.MainImageUrl)
            .NotEmpty().WithMessage("The main image URL is required")
            .Must(BeAValidUrl).WithMessage("The main image URL must be a valid URL");

        RuleFor(x => x.AdditionalImageUrls)
            .ForEach(url => url.Must(BeAValidUrl).WithMessage("Each additional image URL must be a valid URL"));
    }

    private bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}