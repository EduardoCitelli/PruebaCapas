﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaCapas.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregamosColorPiel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdColorPiel",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ColoresPiel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColoresPiel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColoresPiel");

            migrationBuilder.DropColumn(
                name: "IdColorPiel",
                table: "Personas");
        }
    }
}
