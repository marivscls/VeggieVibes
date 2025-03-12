using VeggieVibes.Communication.Responses;

namespace VeggieVibes.Communication.Requests;

public class RequestUpdateRecipeJson
{
    public string Name { get; set; } = string.Empty;
    public List<ResponseRegisterIngredientsJson> Ingredients { get; set; } = [];
}
