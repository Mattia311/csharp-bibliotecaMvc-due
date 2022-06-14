using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_bibliotecaMvc_due.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    AutoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => x.AutoreId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Settore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scaffale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.LibroID);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    UtenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.UtenteID);
                });

            migrationBuilder.CreateTable(
                name: "AutoriLibro",
                columns: table => new
                {
                    AutoriAutoreId = table.Column<int>(type: "int", nullable: false),
                    LibroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoriLibro", x => new { x.AutoriAutoreId, x.LibroID });
                    table.ForeignKey(
                        name: "FK_AutoriLibro_Autore_AutoriAutoreId",
                        column: x => x.AutoriAutoreId,
                        principalTable: "Autore",
                        principalColumn: "AutoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoriLibro_Libro_LibroID",
                        column: x => x.LibroID,
                        principalTable: "Libro",
                        principalColumn: "LibroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestito",
                columns: table => new
                {
                    PrestitoID = table.Column<int>(type: "int", nullable: false),
                    UtenteID = table.Column<int>(type: "int", nullable: false),
                    LibroID = table.Column<int>(type: "int", nullable: false),
                    Dal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Al = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestito", x => x.PrestitoID);
                    table.ForeignKey(
                        name: "FK_Prestito_Libro_LibroID",
                        column: x => x.LibroID,
                        principalTable: "Libro",
                        principalColumn: "LibroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestito_Utente_UtenteID",
                        column: x => x.UtenteID,
                        principalTable: "Utente",
                        principalColumn: "UtenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoriLibro_LibroID",
                table: "AutoriLibro",
                column: "LibroID");

            migrationBuilder.CreateIndex(
                name: "IX_Prestito_LibroID",
                table: "Prestito",
                column: "LibroID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestito_UtenteID",
                table: "Prestito",
                column: "UtenteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoriLibro");

            migrationBuilder.DropTable(
                name: "Prestito");

            migrationBuilder.DropTable(
                name: "Autore");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
