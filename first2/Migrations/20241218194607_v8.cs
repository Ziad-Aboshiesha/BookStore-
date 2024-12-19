using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace first2.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a7b8315-365f-44c8-a666-6130bf0dad3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b8750e-bfef-41fc-9a67-6a0193117cfa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2ec3b15-23a5-402f-a87e-46bb6721c96d", null, "admin", "ADMIN" },
                    { "fb8afc43-eaab-47a6-ba07-e3cf7b116598", null, "customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2ec3b15-23a5-402f-a87e-46bb6721c96d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8afc43-eaab-47a6-ba07-e3cf7b116598");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a7b8315-365f-44c8-a666-6130bf0dad3c", null, "customer", "CUSTOMER" },
                    { "41b8750e-bfef-41fc-9a67-6a0193117cfa", null, "admin", "ADMIN" }
                });
        }
    }
}
