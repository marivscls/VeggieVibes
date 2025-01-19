namespace VeggieVibes.Domain.Entities;

public class Instruction
{
    public long Id { get; set; }
    public long RecipeId { get; set; } // Chave estrangeira para Recipe
    public Recipe Recipe { get; set; } = null!; // Navegação para Recipe
    public string Step { get; set; } = string.Empty; // Descrição da instrução
}
