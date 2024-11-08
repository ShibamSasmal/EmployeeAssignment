using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Test.Migrations
{
    /// <inheritdoc />
    public partial class addlocalisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAppLangMaster",
                columns: table => new
                {
                    LangCode = table.Column<string>(type: "varchar(2)", nullable: false),
                    LangName = table.Column<string>(type: "nvarchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAppLangMaster", x => x.LangCode);
                });

            migrationBuilder.CreateTable(
                name: "TblCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCountryTrans",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangCode = table.Column<string>(type: "varchar(2)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountryTrans", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_TblCountryTrans_TblAppLangMaster_LangCode",
                        column: x => x.LangCode,
                        principalTable: "TblAppLangMaster",
                        principalColumn: "LangCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCountryTrans_TblCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "TblCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_LangCode",
                table: "TblCountryTrans",
                column: "LangCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCountryTrans");

            migrationBuilder.DropTable(
                name: "TblAppLangMaster");

            migrationBuilder.DropTable(
                name: "TblCountries");
        }
    }
}
