namespace VeggieVibes.Domain.Entities;

public class SubstituteIngredient
{
    public long Id { get; set; }
    public long RecipeId { get; set; } // Chave estrangeira para Recipe
    public Recipe Recipe { get; set; } = null!; // Navegação para Recipe    
    public string OriginalIngredient { get; set; } = string.Empty;
    public string Substitute { get; set; } = string.Empty;
}
