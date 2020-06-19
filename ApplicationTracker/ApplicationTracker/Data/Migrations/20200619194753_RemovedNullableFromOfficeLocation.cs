using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class RemovedNullableFromOfficeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30735161-562f-460b-ab91-5e04529671dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661c1892-15ad-4358-9fb5-77d5db07d787", "38d90144-ccd0-4f05-80ad-abe6f2e55620", "Applicant", "APPLICANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661c1892-15ad-4358-9fb5-77d5db07d787");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30735161-562f-460b-ab91-5e04529671dd", "da01cc51-9019-4af2-b439-74b647d9ecca", "Applicant", "APPLICANT" });
        }
    }
}
