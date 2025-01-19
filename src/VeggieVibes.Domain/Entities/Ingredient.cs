namespace VeggieVibes.Domain.Entities;

public class Ingredient
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public int CaloriesPerUnit { get; set; }
}