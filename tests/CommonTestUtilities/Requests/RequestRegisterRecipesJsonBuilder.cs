using Bogus;
using VeggieVibes.Communication.Enums;
using VeggieVibes.Communication.Requests.Recipes;
using VeggieVibes.Communication.Responses.Recipes;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterRecipesJsonBuilder
    {
        public static RequestRecipeJson Build()
        {
            var ingredientFaker = new Faker<RequestRecipeIngredientsJson>()
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.Quantity, f => f.Random.Decimal(0.1m, 5.0m))
                .RuleFor(i => i.UnitOfMeasure, f => f.PickRandom<UnitOfMeasure>());

            var recipeFaker = new Faker<RequestRecipeJson>()
                .RuleFor(r => r.Title, f => f.Lorem.Word())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence())
                .RuleFor(r => r.Ingredients, f => ingredientFaker.Generate(5))
                .RuleFor(r => r.Category, f => f.PickRandom<RecipeCategory>())
                .RuleFor(r => r.Difficulty, f => f.PickRandom<RecipeDifficulty>())
                .RuleFor(r => r.DietType, f => f.PickRandom<DietType>())
                .RuleFor(r => r.MealType, f => f.PickRandom<MealType>())
                .RuleFor(r => r.Origin, f => f.PickRandom<CulinaryOrigin>())
                .RuleFor(r => r.Instructions, f => f.Make(3, () => f.Lorem.Sentence()))
                .RuleFor(r => r.PreparationTimeMinutes, f => f.Random.Int(5, 60))
                .RuleFor(r => r.CookingTimeMinutes, f => f.Random.Int(10, 90))
                .RuleFor(r => r.CaloriesPerServing, f => f.Random.Int(100, 800))
                .RuleFor(r => r.Allergen, f => f.PickRandom<Allergen>())
                .RuleFor(r => r.MainImageUrl, f => f.Internet.Url())
                .RuleFor(r => r.AdditionalImageUrls, f => f.Make(2, () => f.Internet.Url()))
                .RuleFor(r => r.Variations, f => f.Make(2, () => f.Lorem.Sentence()))
                .RuleFor(r => r.SubstituteIngredients, f => f.Make(2, () => f.Lorem.Word()));

            return recipeFaker.Generate();
        }
    }
}
