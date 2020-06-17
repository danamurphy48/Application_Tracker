using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class ApplicantModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20221fc-ce4a-457a-a358-c1fbd8355a5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6a2c874-b520-4bdf-bc7b-11cc99983652", "9c7005a5-7853-446d-9f32-2f0a9b9624ce", "Applicant", "APPLICANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6a2c874-b520-4bdf-bc7b-11cc99983652");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f20221fc-ce4a-457a-a358-c1fbd8355a5c", "9d168044-5e4e-4c07-a9f3-92d204e86eac", "Applicant", "APPLICANT" });
        }
    }
}
