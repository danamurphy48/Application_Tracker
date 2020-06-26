using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class AddedModelsAssesmentQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167b9b35-fc55-4f73-9526-9e91fe258254");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77dfe5e2-49cd-429f-a592-9a69c9d83983", "26e55d8c-b44e-4e62-ad13-0fd7d15df2de", "Applicant", "APPLICANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77dfe5e2-49cd-429f-a592-9a69c9d83983");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167b9b35-fc55-4f73-9526-9e91fe258254", "04b1ef20-007b-4114-835c-39c85e4a23c1", "Applicant", "APPLICANT" });
        }
    }
}
