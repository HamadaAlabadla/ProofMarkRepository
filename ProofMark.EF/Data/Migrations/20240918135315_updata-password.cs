using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatapassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9558ce-ae4d-49a8-802b-ba32cd0f8a41");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c7eca4-69c3-4de0-ac5e-bdc59597bd9a", "29411772-8bd0-45c7-b1b1-1772f442d6c9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c7eca4-69c3-4de0-ac5e-bdc59597bd9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29411772-8bd0-45c7-b1b1-1772f442d6c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ebabfa5-f480-47e5-b5de-b559cbd8286e", null, "Factory", "FACTORY" },
                    { "ddf4cadd-6a2f-4215-88fa-1914d0115677", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "87f89eb4-88a7-44dd-a98b-8b9eaaf28685", 0, "534e8c1f-ff3d-4d02-b2ce-35bc5b4ef740", new DateTime(2024, 9, 18, 16, 53, 9, 705, DateTimeKind.Local).AddTicks(3674), "Admin@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAENj88hJpSwiHfFRUPDREUvZh+YJv6DGz3Pf2cXHnbsPpKvcWV+n7NY4CWlFOQHTvHg==", "1234567890", false, "cf0953be-e7d5-4d8c-b0ae-48052b0b7186", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ddf4cadd-6a2f-4215-88fa-1914d0115677", "87f89eb4-88a7-44dd-a98b-8b9eaaf28685" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ebabfa5-f480-47e5-b5de-b559cbd8286e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ddf4cadd-6a2f-4215-88fa-1914d0115677", "87f89eb4-88a7-44dd-a98b-8b9eaaf28685" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddf4cadd-6a2f-4215-88fa-1914d0115677");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87f89eb4-88a7-44dd-a98b-8b9eaaf28685");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b9558ce-ae4d-49a8-802b-ba32cd0f8a41", null, "Factory", "FACTORY" },
                    { "e6c7eca4-69c3-4de0-ac5e-bdc59597bd9a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "29411772-8bd0-45c7-b1b1-1772f442d6c9", 0, "729483bb-733e-4f4a-9303-8a133ed1ea2a", new DateTime(2024, 9, 18, 13, 12, 1, 942, DateTimeKind.Local).AddTicks(9129), "Admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFNosyBsXR3pS4N4YwA9cM5acajrj5SIyL0SMX4N411i/vNbai+5C3JJggCexSsC5w==", "1234567890", false, "b60d5a98-dc3b-4d85-bb9d-b72eb90d955b", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e6c7eca4-69c3-4de0-ac5e-bdc59597bd9a", "29411772-8bd0-45c7-b1b1-1772f442d6c9" });
        }
    }
}
