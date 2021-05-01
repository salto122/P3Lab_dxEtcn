using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3.Migrations
{
    public partial class addnewtablemyUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mg");

            migrationBuilder.CreateTable(
                name: "Dostawcy",
                schema: "mg",
                columns: table => new
                {
                    IDdostawcy = table.Column<int>(type: "int", nullable: false),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Przedstawiciel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StanowiskoPrzedstawiciela = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KodPocztowy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Kraj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Faks = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    StronaMacierzysta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawcy", x => x.IDdostawcy);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                schema: "mg",
                columns: table => new
                {
                    IDkategorii = table.Column<int>(type: "int", nullable: false),
                    NazwaKategorii = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rysunek = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.IDkategorii);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IDklienta = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Przedstawiciel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StanowiskoPrzedstawiciela = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KodPocztowy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Kraj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Faks = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDKlienta", x => x.IDklienta);
                });

            migrationBuilder.CreateTable(
                name: "MyUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IDpracownika = table.Column<int>(type: "int", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Imię = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ZwrotGrzecznościowy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataZatrudnienia = table.Column<DateTime>(type: "datetime", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KodPocztowy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Kraj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TelefonDomowy = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    TelefonWewnętrzny = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Fotografia = table.Column<byte[]>(type: "image", nullable: true),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Szef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IDpracownika);
                });

            migrationBuilder.CreateTable(
                name: "Spedytorzy",
                columns: table => new
                {
                    IDspedytora = table.Column<int>(type: "int", nullable: false),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedytorzy", x => x.IDspedytora);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                schema: "mg",
                columns: table => new
                {
                    IDproduktu = table.Column<int>(type: "int", nullable: false),
                    NazwaProduktu = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IDdostawcy = table.Column<int>(type: "int", nullable: true),
                    IDkategorii = table.Column<int>(type: "int", nullable: true),
                    IlośćJednostkowa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CenaJednostkowa = table.Column<decimal>(type: "money", nullable: true),
                    StanMagazynu = table.Column<short>(type: "smallint", nullable: true),
                    IlośćZamówiona = table.Column<short>(type: "smallint", nullable: true),
                    StanMinimum = table.Column<short>(type: "smallint", nullable: true),
                    Wycofany = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.IDproduktu);
                    table.ForeignKey(
                        name: "FK_Produkty_Dostawcy",
                        column: x => x.IDdostawcy,
                        principalSchema: "mg",
                        principalTable: "Dostawcy",
                        principalColumn: "IDdostawcy",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produkty_Kategorie",
                        column: x => x.IDkategorii,
                        principalSchema: "mg",
                        principalTable: "Kategorie",
                        principalColumn: "IDkategorii",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamówienia",
                columns: table => new
                {
                    IDzamówienia = table.Column<int>(type: "int", nullable: false),
                    IDklienta = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    IDpracownika = table.Column<int>(type: "int", nullable: true),
                    DataZamówienia = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataWymagana = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataWysyłki = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDspedytora = table.Column<int>(type: "int", nullable: true),
                    Fracht = table.Column<decimal>(type: "money", nullable: true),
                    NazwaOdbiorcy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    AdresOdbiorcy = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MiastoOdbiorcy = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RegionOdbiorcy = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KodPocztowyOdbiorcy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KrajOdbiorcy = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamówienia", x => x.IDzamówienia);
                    table.ForeignKey(
                        name: "FK_Zamówienia_Klienci",
                        column: x => x.IDklienta,
                        principalTable: "Klienci",
                        principalColumn: "IDklienta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamówienia_Pracownicy",
                        column: x => x.IDpracownika,
                        principalTable: "Pracownicy",
                        principalColumn: "IDpracownika",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamówienia_Spedytorzy",
                        column: x => x.IDspedytora,
                        principalTable: "Spedytorzy",
                        principalColumn: "IDspedytora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeZamówienia",
                columns: table => new
                {
                    IDzamówienia = table.Column<int>(type: "int", nullable: false),
                    IDproduktu = table.Column<int>(type: "int", nullable: false),
                    CenaJednostkowa = table.Column<decimal>(type: "money", nullable: false),
                    Ilość = table.Column<short>(type: "smallint", nullable: false),
                    Rabat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeZamowien", x => new { x.IDzamówienia, x.IDproduktu });
                    table.ForeignKey(
                        name: "FK_PozycjeZamówienia_Produkty",
                        column: x => x.IDproduktu,
                        principalSchema: "mg",
                        principalTable: "Produkty",
                        principalColumn: "IDproduktu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjeZamówienia_Zamówienia",
                        column: x => x.IDzamówienia,
                        principalTable: "Zamówienia",
                        principalColumn: "IDzamówienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamówienia_IDproduktu",
                table: "PozycjeZamówienia",
                column: "IDproduktu");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IDdostawcy",
                schema: "mg",
                table: "Produkty",
                column: "IDdostawcy");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IDkategorii",
                schema: "mg",
                table: "Produkty",
                column: "IDkategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Zamówienia_IDklienta",
                table: "Zamówienia",
                column: "IDklienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zamówienia_IDpracownika",
                table: "Zamówienia",
                column: "IDpracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Zamówienia_IDspedytora",
                table: "Zamówienia",
                column: "IDspedytora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyUsers");

            migrationBuilder.DropTable(
                name: "PozycjeZamówienia");

            migrationBuilder.DropTable(
                name: "Produkty",
                schema: "mg");

            migrationBuilder.DropTable(
                name: "Zamówienia");

            migrationBuilder.DropTable(
                name: "Dostawcy",
                schema: "mg");

            migrationBuilder.DropTable(
                name: "Kategorie",
                schema: "mg");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Spedytorzy");
        }
    }
}
