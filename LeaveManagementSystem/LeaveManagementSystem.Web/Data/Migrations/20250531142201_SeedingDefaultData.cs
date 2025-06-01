using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c06326f-2c96-4b57-9efe-e2ec3affcdc0", null, "Employee", "EMPLOYEE" },
                    { "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6", null, "Administrator", "ADMINISTRATOR" },
                    { "d1f3b5c2-4e6a-4c8b-9f0d-7e8f1c2b3a4b", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6", 0, "41ab5db6-845d-433d-8e85-c276dce98f00", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEOkF/2CgY420tAj5w4khIk6GpN2oHLBPE0CiE8jRR/BFkT+lw9xYcQpoYpqc4hVdpQ==", null, false, "320ddeac-a66d-4195-9565-20a97c3758ad", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6", "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c06326f-2c96-4b57-9efe-e2ec3affcdc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1f3b5c2-4e6a-4c8b-9f0d-7e8f1c2b3a4b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6", "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6");
        }
    }
}
