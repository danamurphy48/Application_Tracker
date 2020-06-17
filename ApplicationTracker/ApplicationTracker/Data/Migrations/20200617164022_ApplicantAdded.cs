using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class ApplicantAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6a2c874-b520-4bdf-bc7b-11cc99983652");

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70564b18-df68-4be2-8cb8-d01a004e313c", "c4f3fa67-c6fa-452f-9397-70b08da2a3a7", "Applicant", "APPLICANT" });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_IdentityUserId",
                table: "Applicants",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70564b18-df68-4be2-8cb8-d01a004e313c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6a2c874-b520-4bdf-bc7b-11cc99983652", "9c7005a5-7853-446d-9f32-2f0a9b9624ce", "Applicant", "APPLICANT" });
        }
    }
}
