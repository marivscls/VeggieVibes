namespace VeggieVibes.Domain.Entities;

public class RecipeIngredient
{
    public long RecipeId { get; set; } // Chave estrangeira para Recipe
    public Recipe Recipe { get; set; } = null!; // Navegação para Recipe

    public long IngredientId { get; set; } // Chave estrangeira para Ingredient
    public Ingredient Ingredient { get; set; } = null!; // Navegação para Ingredient

    public string Quantity { get; set; } = string.Empty; // Quantidade do ingrediente na receita (ex: "200g")
    public string Notes { get; set; } = string.Empty; // Observações (ex: "Cortar em cubos")
}