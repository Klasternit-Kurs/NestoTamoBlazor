using Microsoft.EntityFrameworkCore.Migrations;

namespace NestoTamoBlazor.Server.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -1, "Pera", "Peric" });

            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -2, "Neko", "Nekic" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "a", "111", -1, "abc" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "b", "222", -1, "zxc" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "c", "333", -2, "qwe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "b");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
