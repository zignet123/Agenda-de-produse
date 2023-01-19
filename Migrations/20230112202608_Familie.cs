using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda_de_produse.Migrations
{
    public partial class Familie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamilieID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Familie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFamilie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_FamilieID",
                table: "Produs",
                column: "FamilieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Familie_FamilieID",
                table: "Produs",
                column: "FamilieID",
                principalTable: "Familie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Familie_FamilieID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Familie");

            migrationBuilder.DropIndex(
                name: "IX_Produs_FamilieID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "FamilieID",
                table: "Produs");
        }
    }
}
