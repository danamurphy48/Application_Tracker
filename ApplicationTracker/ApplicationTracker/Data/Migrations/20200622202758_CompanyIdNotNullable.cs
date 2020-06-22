using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class CompanyIdNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd172e7d-33b2-4dce-8488-eca21030ef8e");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167b9b35-fc55-4f73-9526-9e91fe258254", "04b1ef20-007b-4114-835c-39c85e4a23c1", "Applicant", "APPLICANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167b9b35-fc55-4f73-9526-9e91fe258254");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd172e7d-33b2-4dce-8488-eca21030ef8e", "52a978ce-eb10-451a-95e8-cc698bfe39fa", "Applicant", "APPLICANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
