using VeggieVibes.Domain.Repositories;
using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Application.UseCases.Recipes.GetById;

public class GetRecipeByIdUseCase : IGetRecipeByIdUseCase
{
    private readonly IRecipesReadOnlyRepository _recipeReadOnlyRepository;

    public GetRecipeByIdUseCase(IRecipesReadOnlyRepository recipesReadOnlyRepository)
    {
        _recipeReadOnlyRepository = recipesReadOnlyRepository;
    }

    public async Task<ResponseGetRecipeByIdJson> Execute(long id)
    {
        var recipe = await _recipeReadOnlyRepository.GetById(id);

        return new ResponseGetRecipeByIdJson
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => new ResponseRegisteredIngredientsJson
            {
                IngredientId = i.Ingredient.Id,
                Name = i.Ingredient.Name,
                Quantity = i.Quantity,
                UnitOfMeasure = (Communication.Enums.UnitOfMeasure)i.UnitOfMeasure,
            }).ToList(),
            Category = (Communication.Enums.RecipeCategory)recipe.Category,
            Difficulty = (Communication.Enums.RecipeDifficulty)recipe.Difficulty,
            DietType = (Communication.Enums.DietType)recipe.DietType,
            MealType = (Communication.Enums.MealType)recipe.MealType,
            Origin = (Communication.Enums.CulinaryOrigin)recipe.Origin,
            Instructions = recipe.Instructions.Select(i => i.Step).ToList(),
            PreparationTimeMinutes = recipe.PreparationTimeMinutes,
            CookingTimeMinutes = recipe.CookingTimeMinutes,
            CaloriesPerServing = recipe.CaloriesPerServing,
            Allergen = (Communication.Enums.Allergen)recipe.Allergen,
            MainImageUrl = recipe.Images.FirstOrDefault()?.Url,
            AdditionalImageUrls = recipe.Images.Select(i => i.Url).ToList(),
            Variations = recipe.Variations.Select(v => v.Description).ToList(),
            SubstituteIngredients = recipe.SubstituteIngredients.Select(si => si.Substitute).ToList()
        };
    }
}