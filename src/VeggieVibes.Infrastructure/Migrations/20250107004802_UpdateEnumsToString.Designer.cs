﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeggieVibes.Infrastructure.DataAccess;

#nullable disable

namespace VeggieVibes.Infrastructure.Migrations
{
    [DbContext(typeof(VeggieVibesDbContext))]
    [Migration("20250107004802_UpdateEnumsToString")]
    partial class UpdateEnumsToString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Allergen", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.DietType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DietTypes");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Instruction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.MealType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CaloriesPerServing")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CookTime")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long>("DietTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MealTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<int>("PreparationTimeMinutes")
                        .HasColumnType("int");

                    b.Property<int>("ServingSize")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DietTypeId");

                    b.HasIndex("MealTypeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.SubstituteIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("OriginalIngredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Substitute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("SubstituteIngredients");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Variation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Variations");
                });

            modelBuilder.Entity("RecipeImage", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Images")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Allergen", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Allergens")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Instruction", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.DietType", "DietType")
                        .WithMany("Recipes")
                        .HasForeignKey("DietTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VeggieVibes.Domain.Entities.MealType", "MealType")
                        .WithMany("Recipes")
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DietType");

                    b.Navigation("MealType");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.SubstituteIngredient", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.Recipe", "Recipe")
                        .WithMany("SubstituteIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Variation", b =>
                {
                    b.HasOne("VeggieVibes.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Variations")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.DietType", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.MealType", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("VeggieVibes.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Allergens");

                    b.Navigation("Images");

                    b.Navigation("Instructions");

                    b.Navigation("SubstituteIngredients");

                    b.Navigation("Variations");
                });
#pragma warning restore 612, 618
        }
    }
}
