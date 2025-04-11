using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Recipes;
using VeggieVibes.Domain.Security.Cryptography;
using VeggieVibes.Infrastructure.DataAccess;
using VeggieVibes.Infrastructure.DataAccess.Recipes;

namespace VeggieVibes.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void Infrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IRecipesReadOnlyRepository, RecipesRepository>();
        services.AddScoped<IRecipesWriteOnlyRepository, RecipesRepository>();
        services.AddScoped<IRecipesUpdateOnlyRepository, RecipesRepository>();
    }
}