using VeggieVibes.Domain.Enums;

namespace VeggieVibes.Domain.Entities;

public class RecipeIngredient
{
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public long IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;
    public decimal Quantity { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
}