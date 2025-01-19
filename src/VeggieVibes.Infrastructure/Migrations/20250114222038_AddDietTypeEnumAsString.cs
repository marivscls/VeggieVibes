using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeggieVibes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDietTypeEnumAsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DietTypes_DietTypeId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "DietTypes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DietTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DietTypeId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "DietType",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DietType",
                table: "Recipes");

            migrationBuilder.AddColumn<long>(
                name: "DietTypeId",
                table: "Recipes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "DietTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DietTypeId",
                table: "Recipes",
                column: "DietTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DietTypes_DietTypeId",
                table: "Recipes",
                column: "DietTypeId",
                principalTable: "DietTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
