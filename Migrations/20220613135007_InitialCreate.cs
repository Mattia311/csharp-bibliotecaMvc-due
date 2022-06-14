using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_bibliotecaMvc_due.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoriLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autore",
                table: "Autore");

            migrationBuilder.DropColumn(
                name: "AutoreId",
                table: "Autore");

            migrationBuilder.AlterColumn<string>(
                name: "Settore",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Autore",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Cognome",
                table: "Autore",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascita",
                table: "Autore",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autore",
                table: "Autore",
                columns: new[] { "Cognome", "Nome", "DataNascita" });

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

            migrationBuilder.CreateIndex(
                name: "IX_AutoreLibro_AutoriCognome_AutoriNome_AutoriDataNascita",
                table: "AutoreLibro",
                columns: new[] { "AutoriCognome", "AutoriNome", "AutoriDataNascita" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoreLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autore",
                table: "Autore");

            migrationBuilder.DropColumn(
                name: "DataNascita",
                table: "Autore");

            migrationBuilder.AlterColumn<string>(
                name: "Settore",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Autore",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Cognome",
                table: "Autore",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "AutoreId",
                table: "Autore",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autore",
                table: "Autore",
                column: "AutoreId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AutoriLibro_LibroID",
                table: "AutoriLibro",
                column: "LibroID");
        }
    }
}
