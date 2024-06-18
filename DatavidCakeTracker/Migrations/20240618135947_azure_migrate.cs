using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatavidCakeTracker.Migrations
{
    /// <inheritdoc />
    public partial class azure_migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5127c29d-6f2a-4a96-ad20-4cd294cb622e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c54510c6-1840-4011-bf56-03496bc9cdbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abbefe38-4f8a-4e6c-a9b4-485bb3835ecd", null, "admin", "admin" },
                    { "f91a870e-fa63-49e4-aa81-bdee2b968bb1", null, "user", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abbefe38-4f8a-4e6c-a9b4-485bb3835ecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91a870e-fa63-49e4-aa81-bdee2b968bb1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5127c29d-6f2a-4a96-ad20-4cd294cb622e", null, "admin", "admin" },
                    { "c54510c6-1840-4011-bf56-03496bc9cdbb", null, "user", "user" }
                });
        }
    }
}
