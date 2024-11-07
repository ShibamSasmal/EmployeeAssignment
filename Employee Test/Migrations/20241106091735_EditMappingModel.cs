using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Test.Migrations
{
    /// <inheritdoc />
    public partial class EditMappingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Years",
                table: "EmployeeDepartmentMapping");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeDepartmentMapping",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeDepartmentMapping",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EmployeeDepartmentMapping");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeDepartmentMapping");

            migrationBuilder.AddColumn<int>(
                name: "Years",
                table: "EmployeeDepartmentMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
