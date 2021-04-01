using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthRate.Migrations
{
    public partial class ReviewsCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "d915a870-413a-4bec-b290-6abfc84988b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Patient",
                column: "ConcurrencyStamp",
                value: "9536ff12-3a1a-4b9c-b709-41ed19890522");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewId",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviews_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviews_ReviewId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReviewId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Doctor",
                column: "ConcurrencyStamp",
                value: "0f7d5218-6cff-440d-acae-2b8f36b67cef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Patient",
                column: "ConcurrencyStamp",
                value: "4bacaeec-33e3-40b9-8902-caa6ce93f501");
        }
    }
}
