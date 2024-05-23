using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCdemo.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "872a6e38-b24e-43d2-a45e-97fd701188c7", null, "User_1", "USER_1" },
                    { "bbe8dc95-4d2f-47ac-b4de-0220dfbc8d8e", null, "User", "USER" },
                    { "dd57287f-721e-478c-9ac8-7bc811dae0e8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "872a6e38-b24e-43d2-a45e-97fd701188c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbe8dc95-4d2f-47ac-b4de-0220dfbc8d8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd57287f-721e-478c-9ac8-7bc811dae0e8");
        }
    }
}
