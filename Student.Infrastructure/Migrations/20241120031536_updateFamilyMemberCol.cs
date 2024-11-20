using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateFamilyMemberCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FamilyMembers",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "FamilyMembers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FamilyMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FamilyMembers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "FamilyMembers",
                newName: "Name");
        }
    }
}
