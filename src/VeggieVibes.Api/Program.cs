using Microsoft.OpenApi.Models;
using VeggieVibes.Infrastructure;
using VeggieVibes.Application.UseCases.Recipes.GetById;
using VeggieVibes.Application;
using VeggieVibes.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Repositories;
using VeggieVibes.Infrastructure.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();

builder.Services.AddApp();

builder.Services.AddInfrastructure();

builder.Services.AddScoped<IGetRecipeByIdUseCase, GetRecipeByIdUseCase>();

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddDbContext<VeggieVibesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VeggieVibes API",
        Version = "v1"
    });
});

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VeggieVibes API v1"));
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
