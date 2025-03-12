using VeggieVibes.Application.UseCases.Recipes.Register;
using VeggieVibes.Communication.Enums;
using VeggieVibes.Communication.Requests;

namespace Validators.Test.Recipes.Register
{
    public class RegisterRecipeValidatorTests
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterRecipeValidator();

            var request = new RequestRegisterRecipesJson
            {
                RecipeId = 1,
                Title = "Salada de Quinoa",
                Description = "Uma salada saudável e deliciosa feita com quinoa, legumes frescos e temperos naturais.",
                Ingredients = new List<RequestRegisterIngredientsJson>
                {
                    new RequestRegisterIngredientsJson { Name = "Quinoa", Quantity = 1.0m, UnitOfMeasure = 1 },  
                    new RequestRegisterIngredientsJson { Name = "Tomate", Quantity = 2.0m, UnitOfMeasure = 2 }, 
                    new RequestRegisterIngredientsJson { Name = "Pepino", Quantity = 1.0m, UnitOfMeasure = 2 }
                },
                Category = RecipeCategory.Salad,
                Difficulty = RecipeDifficulty.Easy,
                DietType = DietType.Vegan,
                MealType = MealType.Lunch,
                Origin = CulinaryOrigin.Mediterranean,
                Instructions = new List<string>
                {
                    "Cozinhe a quinoa de acordo com as instruções da embalagem.",
                    "Pique os tomates e o pepino em cubos pequenos.",
                    "Misture todos os ingredientes e tempere a gosto."
                },
                PreparationTimeMinutes = 15,
                CookingTimeMinutes = 10,
                CaloriesPerServing = 250,
                Allergen = Allergen.Gluten,
                MainImageUrl = "https://example.com/salada-quinoa.jpg",
                AdditionalImageUrls = new List<string>
                {
                    "https://example.com/salada-quinoa-2.jpg",
                    "https://example.com/salada-quinoa-3.jpg"
                },
                Variations = new List<string>
                {
                    "Substituir o pepino por abobrinha.",
                    "Adicionar grão-de-bico cozido."
                },
                SubstituteIngredients = new List<string>
                {
                    "Quinoa pode ser substituída por arroz integral."
                }
            };

            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }
    }
}
