using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Test.Migrations
{
    /// <inheritdoc />
    public partial class addlocalisations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TblCountryTrans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblCountryTrans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                column: "CountryId");
        }
    }
}
