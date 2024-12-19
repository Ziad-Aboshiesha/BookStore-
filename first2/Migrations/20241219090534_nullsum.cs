using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace first2.Migrations
{
    /// <inheritdoc />
    public partial class nullsum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8614e15-54d4-4104-9219-503180c51a24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede5a8f4-1cbe-494b-8a18-4be36ad48134");

            migrationBuilder.AlterColumn<int>(
                name: "sum",
                table: "Authors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a572443-82c1-452c-a25d-4c2df3a57eed", null, "customer", "CUSTOMER" },
                    { "b4de159c-4a5f-40df-bc0b-542a2fac30ae", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a572443-82c1-452c-a25d-4c2df3a57eed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4de159c-4a5f-40df-bc0b-542a2fac30ae");

            migrationBuilder.AlterColumn<int>(
                name: "sum",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e8614e15-54d4-4104-9219-503180c51a24", null, "admin", "ADMIN" },
                    { "ede5a8f4-1cbe-494b-8a18-4be36ad48134", null, "customer", "CUSTOMER" }
                });
        }
    }
}
