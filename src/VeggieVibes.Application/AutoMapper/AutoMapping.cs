using AutoMapper;
using AutoMapper.Internal.Mappers;
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
        CreateMap<RequestRegisterRecipesJson, Recipe>()
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
    }

    private void EntityToResponse()
    {
        CreateMap<Recipe, ResponseRegisteredRecipesJson>()
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => instruction.Step)))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => variation.Description)))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => substitute.Substitute)))
            .ForMember(dest => dest.Allergen, opt => opt.MapFrom(src => src.Allergen))
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(ingredient => new ResponseRegisteredIngredientsJson
                {
                    IngredientId = ingredient.Ingredient.Id,
                    Name = ingredient.Ingredient.Name,
                    Quantity = ingredient.Quantity,
                    UnitOfMeasure = (VeggieVibes.Communication.Enums.UnitOfMeasure)ingredient.UnitOfMeasure
                })));

        CreateMap<Recipe, ResponseShortRecipeJson>();
    }
}