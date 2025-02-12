namespace VeggieVibes.Domain.Entities;

public class Variation
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
}
