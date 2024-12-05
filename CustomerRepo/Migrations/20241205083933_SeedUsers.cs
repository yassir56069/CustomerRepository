using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRepo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BCO_Users",
                columns: new[] { "UserID", "UserName", "UserPass" },
                values: new object[] { 3, "codetext", "pass4560" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BCO_Users",
                keyColumn: "UserID",
                keyValue: 3);
        }
    }
}
