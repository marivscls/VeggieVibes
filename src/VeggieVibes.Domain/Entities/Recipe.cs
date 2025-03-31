using VeggieVibes.Domain.Enums;

namespace VeggieVibes.Domain.Entities;

public class Recipe
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int ServingSize { get; set; }
    public int CaloriesPerServing { get; set; }
    public Allergen Allergen { get; set; }
    public RecipeCategory Category { get; set; }
    public RecipeDifficulty Difficulty { get; set; }
    public MealType MealType { get; set; }
    public CulinaryOrigin Origin { get; set; }
    public DietType DietType { get; set; }
    public List<Instruction> Instructions { get; set; } = [];
    public int PreparationTimeMinutes { get; set; }
    public int CookingTimeMinutes { get; set; }
    public List<RecipeImage> Images { get; set; } = [];
    public List<Variation> Variations { get; set; } = [];
    public List<RecipeIngredient> Ingredients { get; set; } = [];
    public List<SubstituteIngredient> SubstituteIngredients { get; set; } = [];
    public long UserId { get; set; }
    public User User { get; set; } = default!;
}