using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac86ae78-24ce-4634-b3d8-7bc014d49f80", "AQAAAAIAAYagAAAAEFFRuWGWGoHxLAt1PFE1osKW/tTpQHPhRSWuLPIa13WQGLcA+lR8wRiCcBypE8BQmg==", "fb66b0fd-5e01-4a35-b574-43ec33d879db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41ab5db6-845d-433d-8e85-c276dce98f00", "AQAAAAIAAYagAAAAEOkF/2CgY420tAj5w4khIk6GpN2oHLBPE0CiE8jRR/BFkT+lw9xYcQpoYpqc4hVdpQ==", "320ddeac-a66d-4195-9565-20a97c3758ad" });
        }
    }
}
