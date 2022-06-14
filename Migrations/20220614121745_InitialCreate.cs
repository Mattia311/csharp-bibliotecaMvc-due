using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_bibliotecaMvc_due.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    Cognome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => new { x.Cognome, x.Nome, x.DataNascita });
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Settore = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "AutoreLibro",
                columns: table => new
                {
                    LibriLibroID = table.Column<int>(type: "int", nullable: false),
                    AutoriCognome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutoriNome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutoriDataNascita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoreLibro", x => new { x.LibriLibroID, x.AutoriCognome, x.AutoriNome, x.AutoriDataNascita });
                    table.ForeignKey(
                        name: "FK_AutoreLibro_Autore_AutoriCognome_AutoriNome_AutoriDataNascita",
                        columns: x => new { x.AutoriCognome, x.AutoriNome, x.AutoriDataNascita },
                        principalTable: "Autore",
                        principalColumns: new[] { "Cognome", "Nome", "DataNascita" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoreLibro_Libro_LibriLibroID",
                        column: x => x.LibriLibroID,
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
                name: "IX_AutoreLibro_AutoriCognome_AutoriNome_AutoriDataNascita",
                table: "AutoreLibro",
                columns: new[] { "AutoriCognome", "AutoriNome", "AutoriDataNascita" });

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
                name: "AutoreLibro");

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
