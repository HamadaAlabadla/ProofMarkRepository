using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddQRCodeToProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b3026dd-1037-4f27-bd26-25b8b31bb542");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "75dddc2d-3c1b-4ff2-8856-bd609b00fbdd", "f2abd5af-025c-4ad6-928b-7d8a132f1ed7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75dddc2d-3c1b-4ff2-8856-bd609b00fbdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2abd5af-025c-4ad6-928b-7d8a132f1ed7");

            migrationBuilder.AddColumn<string>(
                name: "QRCode",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36540e8b-1dd5-4c4a-82d8-ae0a7d89e26a", null, "Factory", "FACTORY" },
                    { "8c95b49b-55fb-4679-aa9b-647ff56e48b4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "313908ef-a20a-4e82-b64b-254b5914688a", 0, "b12822d0-b057-4da0-b96f-060f5f9700ea", new DateTime(2024, 10, 10, 13, 37, 36, 134, DateTimeKind.Local).AddTicks(4148), "Admin@gmail.com", true, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENm77TJRt2wWCnc2af18QhTxUUmo6F8MMfIAhyc8xW40MOQFYxWpQb7AOp370GmHSg==", "1234567890", false, "32431d36-f8db-4e8e-91fb-f1ee319d88f9", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8c95b49b-55fb-4679-aa9b-647ff56e48b4", "313908ef-a20a-4e82-b64b-254b5914688a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36540e8b-1dd5-4c4a-82d8-ae0a7d89e26a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c95b49b-55fb-4679-aa9b-647ff56e48b4", "313908ef-a20a-4e82-b64b-254b5914688a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c95b49b-55fb-4679-aa9b-647ff56e48b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "313908ef-a20a-4e82-b64b-254b5914688a");

            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "ProductItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75dddc2d-3c1b-4ff2-8856-bd609b00fbdd", null, "Admin", "ADMIN" },
                    { "7b3026dd-1037-4f27-bd26-25b8b31bb542", null, "Factory", "FACTORY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "f2abd5af-025c-4ad6-928b-7d8a132f1ed7", 0, "dac15fe7-2295-428d-a491-679bdf79abfc", new DateTime(2024, 10, 10, 13, 24, 18, 931, DateTimeKind.Local).AddTicks(8698), "Admin@gmail.com", true, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDln5iZseeNOzAx7lU0ECP22lXTzOFry/HAcyilNKQ1SxlWXq5baZknP4HReR/umQA==", "1234567890", false, "ee5d79b6-1f3b-4881-a5bb-eb2a45bcf6ce", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "75dddc2d-3c1b-4ff2-8856-bd609b00fbdd", "f2abd5af-025c-4ad6-928b-7d8a132f1ed7" });
        }
    }
}
