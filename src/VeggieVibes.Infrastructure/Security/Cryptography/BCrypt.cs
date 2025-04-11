using VeggieVibes.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace VeggieVibes.Infrastructure.Security;

internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);    
        return passwordHash;
    }
}


