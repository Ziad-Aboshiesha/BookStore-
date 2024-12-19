using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace first2.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ec34694-f47a-4a94-8a0b-9450f28f0f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f19e5a-a756-4099-a7c1-600a150ded7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1546bed9-2eaa-4ece-97a2-f2c6f84f9b0b", null, "customer", "CUSTOMER" },
                    { "d9c835e8-2d2b-4162-bb60-a1b665707b67", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1546bed9-2eaa-4ece-97a2-f2c6f84f9b0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9c835e8-2d2b-4162-bb60-a1b665707b67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ec34694-f47a-4a94-8a0b-9450f28f0f49", null, "customer", "CUSTOMER" },
                    { "33f19e5a-a756-4099-a7c1-600a150ded7f", null, "admin", "ADMIN" }
                });
        }
    }
}
