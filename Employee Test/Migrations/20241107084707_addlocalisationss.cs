using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee_Test.Migrations
{
    /// <inheritdoc />
    public partial class addlocalisationss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TblCountries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "TblCountries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TblAppLangMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "TblAppLangMaster",
                columns: new[] { "LangCode", "IsDefault", "LangName" },
                values: new object[,]
                {
                    { "ar", false, "Arabic" },
                    { "en", true, "English" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCountries_CreatedAt",
                table: "TblCountries",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TblCountries_CreatedAt",
                table: "TblCountries");

            migrationBuilder.DeleteData(
                table: "TblAppLangMaster",
                keyColumn: "LangCode",
                keyValue: "ar");

            migrationBuilder.DeleteData(
                table: "TblAppLangMaster",
                keyColumn: "LangCode",
                keyValue: "en");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TblCountries");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "TblCountries");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TblAppLangMaster");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");
        }
    }
}
