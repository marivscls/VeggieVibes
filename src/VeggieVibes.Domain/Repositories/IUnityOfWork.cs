namespace VeggieVibes.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}
