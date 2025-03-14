namespace VeggieVibes.Exception.ExceptionsBase;

public abstract class RecipeException : SystemException
{
    protected RecipeException(string message) : base(message)   
    {
        
    }
}
