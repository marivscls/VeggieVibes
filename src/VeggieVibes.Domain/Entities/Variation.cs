namespace VeggieVibes.Domain.Entities;

public class Variation
{
    public long Id { get; set; }
    public long RecipeId { get; set; } // Chave estrangeira para Recipe
    public Recipe Recipe { get; set; } = null!; // Navegação para Recipe
    public string Description { get; set; } = string.Empty;
}
