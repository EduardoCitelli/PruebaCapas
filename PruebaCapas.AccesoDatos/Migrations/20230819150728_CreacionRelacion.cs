using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaCapas.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdColorPiel",
                table: "Personas",
                column: "IdColorPiel");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_ColoresPiel_IdColorPiel",
                table: "Personas",
                column: "IdColorPiel",
                principalTable: "ColoresPiel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_ColoresPiel_IdColorPiel",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdColorPiel",
                table: "Personas");
        }
    }
}
