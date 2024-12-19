using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace first2.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2ec3b15-23a5-402f-a87e-46bb6721c96d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8afc43-eaab-47a6-ba07-e3cf7b116598");

            migrationBuilder.AddColumn<string>(
                name: "Customer_address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ec34694-f47a-4a94-8a0b-9450f28f0f49", null, "customer", "CUSTOMER" },
                    { "33f19e5a-a756-4099-a7c1-600a150ded7f", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ec34694-f47a-4a94-8a0b-9450f28f0f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f19e5a-a756-4099-a7c1-600a150ded7f");

            migrationBuilder.DropColumn(
                name: "Customer_address",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2ec3b15-23a5-402f-a87e-46bb6721c96d", null, "admin", "ADMIN" },
                    { "fb8afc43-eaab-47a6-ba07-e3cf7b116598", null, "customer", "CUSTOMER" }
                });
        }
    }
}
