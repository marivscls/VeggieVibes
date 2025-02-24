using Microsoft.Extensions.DependencyInjection;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Infrastructure.DataAccess;
using VeggieVibes.Infrastructure.DataAccess.Repositories;

namespace VeggieVibes.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IRecipesReadOnlyRepository, RecipesRepository>();
        services.AddScoped<IRecipesWriteOnlyRepository, RecipesRepository>();
    }
}