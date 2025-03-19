using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Communication.Requests;

public class RequestRecipeJson
{
    //public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RequestRegisterIngredientsJson> Ingredients { get; set; } = [];
    public RecipeCategory Category { get; set; }
    public RecipeDifficulty Difficulty { get; set; }
    public DietType DietType { get; set; }
    public MealType MealType { get; set; }
    public CulinaryOrigin Origin { get; set; }
    public List<string> Instructions { get; set; } = [];
    public int PreparationTimeMinutes { get; set; }
    public int CookingTimeMinutes { get; set; }
    public int CaloriesPerServing { get; set; }
    public Allergen Allergen { get; set; }
    public string MainImageUrl { get; set; } = string.Empty;
    public List<string> AdditionalImageUrls { get; set; } = [];
    public List<string> Variations { get; set; } = [];
    public List<string> SubstituteIngredients { get; set; } = [];
}
