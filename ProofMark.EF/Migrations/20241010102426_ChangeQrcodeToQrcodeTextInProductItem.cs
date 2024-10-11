using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQrcodeToQrcodeTextInProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5146d809-bd25-4f87-814f-cde3d67b3568");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8ff31fb4-7c4f-44e1-a96a-6215fe883420", "69bd8653-d26b-460a-b855-312de5bb33de" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff31fb4-7c4f-44e1-a96a-6215fe883420");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69bd8653-d26b-460a-b855-312de5bb33de");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                table: "ProductItems",
                newName: "QRCodeText");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "QRCodeText",
                table: "ProductItems",
                newName: "QRCode");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5146d809-bd25-4f87-814f-cde3d67b3568", null, "Factory", "FACTORY" },
                    { "8ff31fb4-7c4f-44e1-a96a-6215fe883420", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "69bd8653-d26b-460a-b855-312de5bb33de", 0, "f258905b-fc93-40ca-bb38-5403f4a017ee", new DateTime(2024, 9, 25, 13, 44, 33, 530, DateTimeKind.Local).AddTicks(851), "Admin@gmail.com", true, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFD2/+AEaijH3vse5Pf/Y9vLxPRZyJvoXJHP1uySUHc7uYp2BfB8f98IZSKemCPeOA==", "1234567890", false, "1ea0acb2-22a3-4298-9134-8d236f995f68", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8ff31fb4-7c4f-44e1-a96a-6215fe883420", "69bd8653-d26b-460a-b855-312de5bb33de" });
        }
    }
}
