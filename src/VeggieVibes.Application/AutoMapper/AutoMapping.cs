using AutoMapper;
using VeggieVibes.Communication.Enums;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Entities;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRecipeJson, Recipe>()
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => new Instruction { Step = instruction })))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => new Variation { Description = variation })))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => new SubstituteIngredient
                {
                    OriginalIngredient = substitute,
                    Substitute = substitute
                })))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(ingredient => new RecipeIngredient
                {
                    Ingredient = new Ingredient { Name = ingredient.Name },
                    Quantity = ingredient.Quantity,
                    UnitOfMeasure = (VeggieVibes.Domain.Enums.UnitOfMeasure)ingredient.UnitOfMeasure
                })));

        CreateMap<RequestUpdateRecipeJson, Recipe>()
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => new Instruction { Step = instruction }).ToList()))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => new Variation { Description = variation }).ToList()))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => new SubstituteIngredient
                {
                    OriginalIngredient = substitute,
                    Substitute = substitute
                }).ToList()))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(ingredient => new RecipeIngredient
                {
                    Ingredient = new Ingredient { Name = ingredient.Name },
                    Quantity = ingredient.Quantity,
                    UnitOfMeasure = (VeggieVibes.Domain.Enums.UnitOfMeasure)ingredient.UnitOfMeasure
                }).ToList()))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.RecipeCategory)src.Category))
            .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.RecipeDifficulty)src.Difficulty))
            .ForMember(dest => dest.DietType, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.DietType)src.DietType))
            .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.MealType)src.MealType))
            .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.CulinaryOrigin)src.Origin))
            .ForMember(dest => dest.Allergen, opt => opt.MapFrom(src => (VeggieVibes.Domain.Enums.Allergen)src.Allergen));
    }

    private void EntityToResponse()
    {
        CreateMap<Recipe, ResponseRecipeJson>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => instruction.Step)))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => variation.Description)))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => substitute.Substitute)))
            .ForMember(dest => dest.Allergen, opt => opt.MapFrom(src => src.Allergen))
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(ingredient => new RequestRecipeIngredientsJson
                {
                    IngredientId = ingredient.Ingredient.Id,
                    Name = ingredient.Ingredient.Name,
                    Quantity = ingredient.Quantity,
                    UnitOfMeasure = (VeggieVibes.Communication.Enums.UnitOfMeasure)ingredient.UnitOfMeasure
                })));

        CreateMap<Recipe, ResponseUpdateRecipeJson>();
        CreateMap<Recipe, ResponseShortRecipeJson>();
        CreateMap<Recipe, ResponseGetRecipeByIdJson>();
    }
}