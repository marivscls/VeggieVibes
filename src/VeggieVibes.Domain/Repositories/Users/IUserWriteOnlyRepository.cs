using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories.Users
{
    public interface IRegisterUserWriteOnlyRepository
    {
        Task Add(User user);
    }
}
