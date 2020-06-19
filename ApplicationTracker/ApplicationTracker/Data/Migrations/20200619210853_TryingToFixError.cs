using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class TryingToFixError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661c1892-15ad-4358-9fb5-77d5db07d787");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd172e7d-33b2-4dce-8488-eca21030ef8e", "52a978ce-eb10-451a-95e8-cc698bfe39fa", "Applicant", "APPLICANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd172e7d-33b2-4dce-8488-eca21030ef8e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661c1892-15ad-4358-9fb5-77d5db07d787", "38d90144-ccd0-4f05-80ad-abe6f2e55620", "Applicant", "APPLICANT" });
        }
    }
}
