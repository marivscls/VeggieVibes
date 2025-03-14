namespace VeggieVibes.Exception.ExceptionsBase;

public class ErrorOnValidationException : RecipeException
{
    public List<string> Errors { get; }
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        Errors = errorMessages;
    }
}
