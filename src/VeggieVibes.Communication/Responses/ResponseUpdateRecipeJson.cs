using System.Data.Common;
using VeggieVibes.Communication.Enums;

namespace VeggieVibes.Communication.Responses;

public class ResponseUpdateRecipeJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ResponseRegisteredIngredientsJson> Ingredients { get; set; } = [];
}
