using Microsoft.EntityFrameworkCore.Migrations;

namespace NestoTamoBlazor.Server.Migrations
{
    public partial class NavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresas_Korisniks_KorisnikID",
                table: "Adresas");

            migrationBuilder.DropIndex(
                name: "IX_Adresas_KorisnikID",
                table: "Adresas");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Adresas");

            migrationBuilder.AddColumn<int>(
                name: "Korisnik_FK",
                table: "Adresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_Korisnik_FK",
                table: "Adresas",
                column: "Korisnik_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresas_Korisniks_Korisnik_FK",
                table: "Adresas",
                column: "Korisnik_FK",
                principalTable: "Korisniks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresas_Korisniks_Korisnik_FK",
                table: "Adresas");

            migrationBuilder.DropIndex(
                name: "IX_Adresas_Korisnik_FK",
                table: "Adresas");

            migrationBuilder.DropColumn(
                name: "Korisnik_FK",
                table: "Adresas");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Adresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_KorisnikID",
                table: "Adresas",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresas_Korisniks_KorisnikID",
                table: "Adresas",
                column: "KorisnikID",
                principalTable: "Korisniks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
