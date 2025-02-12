namespace VeggieVibes.Domain.Entities;

public class Instruction
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string Step { get; set; } = string.Empty;
}
