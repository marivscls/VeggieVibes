namespace VeggieVibes.Exception.ExceptionsBase;

public abstract class RecipeException : SystemException
{
    protected RecipeException(string message) : base(message)   
    {
        
    }
    public virtual List<string> GetErrors()
    {
        return new List<string> { Message };
    }
}
