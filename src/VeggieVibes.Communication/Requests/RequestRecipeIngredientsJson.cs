using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Communication.Responses;

public class RequestRecipeIngredientsJson
{
    public long IngredientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
}
