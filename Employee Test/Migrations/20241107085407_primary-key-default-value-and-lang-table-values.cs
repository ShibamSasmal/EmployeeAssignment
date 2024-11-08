using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Test.Migrations
{
    /// <inheritdoc />
    public partial class primarykeydefaultvalueandlangtablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountryTrans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                columns: new[] { "Id", "CountryId", "LangCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId_LangCode",
                table: "TblCountryTrans",
                columns: new[] { "CountryId", "LangCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountryTrans_CountryId_LangCode",
                table: "TblCountryTrans");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountryTrans",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans",
                column: "CountryId");
        }
    }
}
