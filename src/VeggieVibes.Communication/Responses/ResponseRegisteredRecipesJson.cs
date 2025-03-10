using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Communication.Responses;

public class ResponseRegisteredRecipesJson
{
    public long RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ResponseRegisteredIngredientsJson> Ingredients { get; set; } = new();
    public RecipeCategory Category { get; set; }
    public RecipeDifficulty Difficulty { get; set; }
    public DietType DietType { get; set; }
    public MealType MealType { get; set; }
    public CulinaryOrigin Origin { get; set; }
    public List<string>? Instructions { get; set; }
    public int PreparationTimeMinutes { get; set; }
    public int CaloriesPerServing { get; set; }
    public List<string>? Tags { get; set; }
    public Allergen Allergen { get; set; }
    public string? MainImageUrl { get; set; }
    public List<string>? AdditionalImageUrls { get; set; }
    public List<string>? Variations { get; set; }
    public List<string>? SubstituteIngredients { get; set; }
}
