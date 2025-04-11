namespace VeggieVibes.Domain.Security.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
    }
}
