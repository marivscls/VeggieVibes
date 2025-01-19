using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Communication.Requests;

public class RequestRegisterRecipesJson
{
    public int RecipeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RecipeCategory Category { get; set; }
    public RecipeDifficulty Difficulty { get; set; }
    public DietType DietType { get; set; }
    public MealType MealType { get; set; }
    public CulinaryOrigin Origin { get; set; }

    // Detalhes de preparo
    public List<string>? Instructions { get; set; }
    public int PreparationTimeMinutes { get; set; }
    public int CookingTimeMinutes { get; set; }
    public int ServingsCount { get; set; }

    // Informações nutricionais
    public int CaloriesPerServing { get; set; }

    // Tags e categorias adicionais
    // public List<string>? Tags { get; set; }
    public Allergen Allergen { get; set; }

    // Imagem
    public string MainImageUrl { get; set; } = string.Empty;
    public List<string>? AdditionalImageUrls { get; set; }

    // Notas adicionais
    public List<string>? Variations { get; set; }
    public List<string>? SubstituteIngredients { get; set; }
}
