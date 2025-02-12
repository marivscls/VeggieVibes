using VeggieVibes.Domain.Enums;

namespace VeggieVibes.Domain.Entities;

public class Ingredient
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}