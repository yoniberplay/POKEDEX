using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class CambiodenombreacolumnaSecondaryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_tipos_SecondType",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "SecondType",
                table: "Pokemons",
                newName: "SecondaryType");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemons_SecondType",
                table: "Pokemons",
                newName: "IX_Pokemons_SecondaryType");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_tipos_SecondaryType",
                table: "Pokemons",
                column: "SecondaryType",
                principalTable: "tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_tipos_SecondaryType",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "SecondaryType",
                table: "Pokemons",
                newName: "SecondType");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemons_SecondaryType",
                table: "Pokemons",
                newName: "IX_Pokemons_SecondType");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_tipos_SecondType",
                table: "Pokemons",
                column: "SecondType",
                principalTable: "tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
