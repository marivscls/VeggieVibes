using AutoMapper;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Domain.Entities;
namespace VeggieVibes.Application.AutoMapper;

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
                src.Instructions != null ?
                src.Instructions.Select(instruction => new Instruction { Step = instruction }).ToList() :
                new List<Instruction>()))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations != null ?
                src.Variations.Select(variation => new Variation { Description = variation }).ToList() :
                new List<Variation>()))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients != null ?
                src.SubstituteIngredients.Select(substitute => new SubstituteIngredient
                {
                    OriginalIngredient = substitute,
                    Substitute = substitute
                }).ToList() :
                new List<SubstituteIngredient>()));
    }

    private void EntityToResponse()
    {
        CreateMap<Recipe, RequestRegisterRecipesJson>()
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => instruction.Step).ToList()))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => variation.Description).ToList()))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => substitute.Substitute).ToList()));

        CreateMap<Recipe, ResponseRegisterRecipesJson>()
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src =>
                src.Instructions.Select(instruction => instruction.Step).ToList()))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src =>
                src.Variations.Select(variation => variation.Description).ToList()))
            .ForMember(dest => dest.SubstituteIngredients, opt => opt.MapFrom(src =>
                src.SubstituteIngredients.Select(substitute => substitute.Substitute).ToList()))
            .ForMember(dest => dest.Allergen, opt => opt.MapFrom(src => src.Allergen))
            .ForMember(dest => dest.Tags, opt => opt.Ignore());
    }
}