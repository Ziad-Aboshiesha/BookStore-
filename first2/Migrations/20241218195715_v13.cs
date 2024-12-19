using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first2.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer_address",
                table: "AspNetUsers",
                newName: "add");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "add",
                table: "AspNetUsers",
                newName: "Customer_address");
        }
    }
}
