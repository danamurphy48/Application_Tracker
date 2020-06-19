using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTracker.Data.Migrations
{
    public partial class NullableFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobInformations_JobInfoId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Networks_NetworkId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyNotes_CompanyNotesId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_HiringManagers_HiringManagerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "253fe6b3-0111-400f-b210-6fcab0bdf5b9");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewerId",
                table: "Interviews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HiringManagerId",
                table: "Interviews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyNotesId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PositionTitle",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NetworkId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobInfoId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30735161-562f-460b-ab91-5e04529671dd", "da01cc51-9019-4af2-b439-74b647d9ecca", "Applicant", "APPLICANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobInformations_JobInfoId",
                table: "Applications",
                column: "JobInfoId",
                principalTable: "JobInformations",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Networks_NetworkId",
                table: "Applications",
                column: "NetworkId",
                principalTable: "Networks",
                principalColumn: "NetworkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyNotes_CompanyNotesId",
                table: "Companies",
                column: "CompanyNotesId",
                principalTable: "CompanyNotes",
                principalColumn: "CompanyNotesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_HiringManagers_HiringManagerId",
                table: "Interviews",
                column: "HiringManagerId",
                principalTable: "HiringManagers",
                principalColumn: "HiringManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "InterviewerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobInformations_JobInfoId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Networks_NetworkId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyNotes_CompanyNotesId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_HiringManagers_HiringManagerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30735161-562f-460b-ab91-5e04529671dd");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewerId",
                table: "Interviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HiringManagerId",
                table: "Interviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyNotesId",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionTitle",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NetworkId",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobInfoId",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "253fe6b3-0111-400f-b210-6fcab0bdf5b9", "de7cc2da-b13a-4397-8bb7-aec52783298e", "Applicant", "APPLICANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobInformations_JobInfoId",
                table: "Applications",
                column: "JobInfoId",
                principalTable: "JobInformations",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Networks_NetworkId",
                table: "Applications",
                column: "NetworkId",
                principalTable: "Networks",
                principalColumn: "NetworkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyNotes_CompanyNotesId",
                table: "Companies",
                column: "CompanyNotesId",
                principalTable: "CompanyNotes",
                principalColumn: "CompanyNotesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_HiringManagers_HiringManagerId",
                table: "Interviews",
                column: "HiringManagerId",
                principalTable: "HiringManagers",
                principalColumn: "HiringManagerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "InterviewerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
