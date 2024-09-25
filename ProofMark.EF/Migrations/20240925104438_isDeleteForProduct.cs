using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Migrations
{
    /// <inheritdoc />
    public partial class isDeleteForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5cce584-2b92-404a-9490-0703413dbdb8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c091155-67de-4317-ae66-df124c4c3fca", "8cbd43c7-1d7c-4e57-a51e-c2b35f41be3c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c091155-67de-4317-ae66-df124c4c3fca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cbd43c7-1d7c-4e57-a51e-c2b35f41be3c");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c091155-67de-4317-ae66-df124c4c3fca", null, "Admin", "ADMIN" },
                    { "d5cce584-2b92-404a-9490-0703413dbdb8", null, "Factory", "FACTORY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "8cbd43c7-1d7c-4e57-a51e-c2b35f41be3c", 0, "ec0f41ae-a56f-4d32-bfca-83e51008d713", new DateTime(2024, 9, 25, 13, 14, 45, 272, DateTimeKind.Local).AddTicks(8874), "Admin@gmail.com", true, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENZSZCwxaXV++A8yQ5ehwe4hzyAWT0/Z+u3qGINCE4Jxmlb4NVG3C5dq8ihjSGQFIg==", "1234567890", false, "bdf36ade-0244-4387-83ea-f8d63c1993c8", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9c091155-67de-4317-ae66-df124c4c3fca", "8cbd43c7-1d7c-4e57-a51e-c2b35f41be3c" });
        }
    }
}
