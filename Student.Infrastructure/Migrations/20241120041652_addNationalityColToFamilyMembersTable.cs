using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNationalityColToFamilyMembersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_NationalityId",
                table: "FamilyMembers",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Nationalities_NationalityId",
                table: "FamilyMembers",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Nationalities_NationalityId",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_NationalityId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "FamilyMembers");
        }
    }
}
