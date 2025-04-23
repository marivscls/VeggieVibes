using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeggieVibes.Application.UseCases.Recipes.GetById;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Domain.Repositories.Recipes;
using VeggieVibes.Domain.Repositories.Users;
using VeggieVibes.Domain.Security.Cryptography;
using VeggieVibes.Domain.Security.Tokens;
using VeggieVibes.Infrastructure.DataAccess;
using VeggieVibes.Infrastructure.DataAccess.Recipes;
using VeggieVibes.Infrastructure.Security.Token;

namespace VeggieVibes.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddToken(services, configuration);
        services.AddScoped<IPasswordEncripter, Security.BCrypt>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IRecipesReadOnlyRepository, RecipesRepository>();
        services.AddScoped<IRecipesWriteOnlyRepository, RecipesRepository>();
        services.AddScoped<IRecipesUpdateOnlyRepository, RecipesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
}
