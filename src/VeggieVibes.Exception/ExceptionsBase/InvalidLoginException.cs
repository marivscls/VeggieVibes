using System.Net;

namespace VeggieVibes.Exception.ExceptionsBase;

public class InvalidLoginException : RecipeException
{
    public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID)
    {
    }

    public int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}

