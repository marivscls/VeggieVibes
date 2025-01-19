using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeggieVibes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMealTypeEnumAsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_MealTypes_MealTypeId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Recipes");

            migrationBuilder.AddColumn<long>(
                name: "MealTypeId",
                table: "Recipes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealTypeId",
                table: "Recipes",
                column: "MealTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_MealTypes_MealTypeId",
                table: "Recipes",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
