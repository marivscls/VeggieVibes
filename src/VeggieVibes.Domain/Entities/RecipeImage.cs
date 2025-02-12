using VeggieVibes.Domain.Entities;

public class RecipeImage
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string Url { get; set; } = string.Empty;
}
