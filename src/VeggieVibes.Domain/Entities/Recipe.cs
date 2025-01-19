using VeggieVibes.Domain.Enums;

namespace VeggieVibes.Domain.Entities;

public class Recipe
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty; // Título obrigatório
    public string? Description { get; set; } // Descrição opcional
    public int PrepTime { get; set; } // Tempo de preparo em minutos
    public int CookTime { get; set; } // Tempo de cozimento em minutos
    public int ServingSize { get; set; } // Número de porções
    public int CaloriesPerServing { get; set; } // Calorias por porção
    public Allergen Allergen { get; set; }
    public RecipeCategory Category { get; set; }
    public RecipeDifficulty Difficulty { get; set; }
    public MealType MealType { get; set; }
    public CulinaryOrigin Origin { get; set; }
    // public long DietTypeId { get; set; } // Chave estrangeira para DietType
    public DietType DietType { get; set; }
    public List<Instruction> Instructions { get; set; } = [];
    public int PreparationTimeMinutes { get; set; }
    public List<RecipeImage> Images { get; set; } = [];
    public List<Variation> Variations { get; set; } = [];
    public List<SubstituteIngredient> SubstituteIngredients { get; set; } = [];
}