using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    NIM = table.Column<string>(type: "TEXT", nullable: false),
                    BinusianId = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ActiveSemester = table.Column<int>(type: "INTEGER", nullable: false),
                    BinusianStatus = table.Column<string>(type: "TEXT", nullable: false),
                    NIK = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    NPWP = table.Column<string>(type: "TEXT", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BankBranch = table.Column<string>(type: "TEXT", nullable: false),
                    AccountHolderName = table.Column<string>(type: "TEXT", nullable: false),
                    ParentGuardianName = table.Column<string>(type: "TEXT", nullable: false),
                    ParentGuardianPhone = table.Column<string>(type: "TEXT", nullable: false),
                    EmergencyContact = table.Column<string>(type: "TEXT", nullable: false),
                    EmergencyRelation = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_BinusianId",
                table: "Staffs",
                column: "BinusianId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
