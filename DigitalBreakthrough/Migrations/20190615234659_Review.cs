using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalBreakthrough.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CleannessReview",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ErgonomicsReview",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolitenessReview",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualityReview",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeedReview",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Doctor",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "0f7d5218-6cff-440d-acae-2b8f36b67cef", "DOCTOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Patient",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "4bacaeec-33e3-40b9-8902-caa6ce93f501", "PATIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleannessReview",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ErgonomicsReview",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PolitenessReview",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "QualityReview",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "SpeedReview",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Doctor",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "bcc80972-855b-4c96-a22d-0e3be2dcff1c", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Patient",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "793b73c3-66b0-4435-a33f-6114fc648129", null });
        }
    }
}
