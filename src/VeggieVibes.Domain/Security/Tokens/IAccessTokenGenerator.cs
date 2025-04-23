using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Security.Tokens
{  
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
