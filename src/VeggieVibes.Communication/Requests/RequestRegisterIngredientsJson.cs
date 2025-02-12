namespace VeggieVibes.Communication.Requests;

public class RequestRegisterIngredientsJson
{
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public int UnitOfMeasure { get; set; }
}
