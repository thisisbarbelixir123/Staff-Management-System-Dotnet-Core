using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStartAndEndDateToStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "Staffs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Staffs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Staffs");
        }
    }
}
