using FluentValidation;
using VeggieVibes.Communication.Requests;

namespace VeggieVibes.Application.Validators;

public class RecipeValidator : AbstractValidator<RequestRegisterRecipesJson>
{
    public RecipeValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O título da receita é obrigatório")
            .MaximumLength(100)
            .WithMessage("O título deve ter no máximo 100 caracteres");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição da receita é obrigatória")
            .MaximumLength(500)
            .WithMessage("A descrição deve ter no máximo 500 caracteres");

        RuleFor(x => x.Ingredients)
            .NotEmpty()
            .WithMessage("A receita deve ter pelo menos um ingrediente");

        RuleFor(x => x.Instructions)
            .NotEmpty()
            .WithMessage("A receita deve ter pelo menos uma instrução");

        RuleFor(x => x.PreparationTimeMinutes)
            .GreaterThan(0)
            .WithMessage("O tempo de preparação deve ser maior que zero");

        RuleFor(x => x.CookingTimeMinutes)
            .GreaterThan(0)
            .WithMessage("O tempo de cozimento deve ser maior que zero");

        RuleFor(x => x.CaloriesPerServing)
            .GreaterThan(0)
            .WithMessage("As calorias por porção devem ser maiores que zero");
    }
}