namespace VeggieVibes.Domain.Entities;

public class SubstituteIngredient
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string OriginalIngredient { get; set; } = string.Empty;
    public string Substitute { get; set; } = string.Empty;
}
