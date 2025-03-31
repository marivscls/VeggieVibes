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
    public DbSet<Variation> Variations { get; set; } = null!;
    public DbSet<SubstituteIngredient> SubstituteIngredients { get; set; } = null!;
    public DbSet<RecipeImage> Images { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.Property(r => r.Id)
                 .UseIdentityColumn(1, 1);

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

            entity.HasMany(r => r.Ingredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

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

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(i => i.Id)
                 .UseIdentityColumn(1, 1);

            entity.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(i => i.UnitOfMeasure)
                .HasConversion(
                    a => a.ToString(),
                    a => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), a));
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            entity.HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(ri => ri.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(ri => ri.UnitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v));
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Id)
                .UseIdentityColumn(1, 1);

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.UserIdentifier)
                .IsRequired();

            entity.HasIndex(u => u.UserIdentifier)
                .IsUnique();

            entity.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50);
        });
    }
}