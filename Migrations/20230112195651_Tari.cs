using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda_de_produse.Migrations
{
    public partial class Tari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Furnizor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTara = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnizor_TaraID",
                table: "Furnizor",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnizor_Tara_TaraID",
                table: "Furnizor",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnizor_Tara_TaraID",
                table: "Furnizor");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Furnizor_TaraID",
                table: "Furnizor");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Furnizor");
        }
    }
}
