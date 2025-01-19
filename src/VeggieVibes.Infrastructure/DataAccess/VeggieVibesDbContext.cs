using Microsoft.EntityFrameworkCore;
using VeggieVibes.Domain.Entities;
using VeggieVibes.Domain.Enums;

namespace VeggieVibes.Infrastructure.DataAccess;
public class VeggieVibesDbContext : DbContext
{
        public VeggieVibesDbContext(DbContextOptions<VeggieVibesDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Instruction> Instructions { get; set; } = null!;
        public DbSet<Variation>? Variations { get; set; }
        public DbSet<SubstituteIngredient>? SubstituteIngredients { get; set; }
        public DbSet<RecipeImage> Images { get; set; } = null!;

        //Configuração do modelo de banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Recipe>(entity =>
                {
                        entity.HasKey(r => r.Id);

                        entity.Property(r => r.Title)
                        .IsRequired()
                        .HasMaxLength(200);

                        entity.Property(r => r.Description)
                        .HasMaxLength(2000);

                        entity.Property(r => r.PrepTime)
                        .IsRequired();

                        entity.Property(r => r.CookTime)
                        .IsRequired();

                        entity.Property(r => r.ServingSize)
                        .IsRequired();

                        entity.Property(r => r.CaloriesPerServing)
                          .IsRequired();

                        // Relacionamentos

                        entity.HasMany(r => r.Instructions)
                        .WithOne(i => i.Recipe)
                        .HasForeignKey(i => i.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

                        entity.HasMany(r => r.Variations)
                        .WithOne(v => v.Recipe)
                        .HasForeignKey(v => v.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

                        entity.HasMany(r => r.SubstituteIngredients)
                        .WithOne(si => si.Recipe)
                        .HasForeignKey(si => si.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

                        entity.HasMany(r => r.Images)
                        .WithOne(ri => ri.Recipe)
                        .HasForeignKey(ri => ri.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);

                        // Configuração de enums para serem armazenados como strings
                        entity.Property(r => r.Origin)
                    .HasConversion(
                        v => v.ToString(),
                        v => (CulinaryOrigin)Enum.Parse(typeof(CulinaryOrigin), v));

                        entity.Property(r => r.Category)
                    .HasConversion(
                        v => v.ToString(),
                        v => (RecipeCategory)Enum.Parse(typeof(RecipeCategory), v));

                        entity.Property(r => r.Difficulty)
                    .HasConversion(
                        v => v.ToString(),
                        v => (RecipeDifficulty)Enum.Parse(typeof(RecipeDifficulty), v));

                        entity.Property(r => r.DietType)
                    .HasConversion(
                        v => v.ToString(),
                        v => (DietType)Enum.Parse(typeof(DietType), v));

                        entity.Property(r => r.MealType)
                    .HasConversion(
                        v => v.ToString(),
                        v => (MealType)Enum.Parse(typeof(MealType), v));

                        entity.Property(r => r.Allergen)
                        .HasConversion(
                        v => v.ToString(),
                        v => (Allergen)Enum.Parse(typeof(Allergen), v));
                });

        }

}