using Microsoft.Extensions.DependencyInjection;
using VeggieVibes.Application.UseCases.Recipes.Delete;
using VeggieVibes.Application.UseCases.Recipes.GetAll;
using VeggieVibes.Application.UseCases.Recipes.GetById;
using VeggieVibes.Application.UseCases.Recipes.Register;
using VeggieVibes.Application.UseCases.Recipes.Update;
namespace VeggieVibes.Application;

public static class DependencyInjectionExtension
{
    public static void AddApp(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisteredRecipesUseCase, RegisterRecipesUseCase>();
        services.AddScoped<IGetRecipeByIdUseCase, GetRecipeByIdUseCase>();
        services.AddScoped<IGetAllRecipesUseCase, GetAllRecipesUseCase>();
        services.AddScoped<IUpdateRecipeUseCase, UpdateRecipeUseCase>();
    }
}
