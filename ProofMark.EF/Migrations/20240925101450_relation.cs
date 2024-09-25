using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bbc0cc8-3c88-4e18-8b8a-0f3c67419c24");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7901b670-a5fb-40a4-8404-e24a01b2220b", "e8da1e5e-838e-439a-8bca-f025d23e06b0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7901b670-a5fb-40a4-8404-e24a01b2220b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8da1e5e-838e-439a-8bca-f025d23e06b0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7901b670-a5fb-40a4-8404-e24a01b2220b", null, "Admin", "ADMIN" },
                    { "8bbc0cc8-3c88-4e18-8b8a-0f3c67419c24", null, "Factory", "FACTORY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "e8da1e5e-838e-439a-8bca-f025d23e06b0", 0, "00c09de4-e2fa-47d0-896b-6ba8befcb9db", new DateTime(2024, 9, 21, 10, 51, 9, 118, DateTimeKind.Local).AddTicks(7624), "Admin@gmail.com", true, true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKWXUlaGZEoNXTFpSHN1VQ3A97rDqWVeXuYFP2D/+8CtuG9sVX0UuNh8sLcWoNX+rw==", "1234567890", false, "b4c8ca62-3dc8-428d-a396-bf31f677f30b", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7901b670-a5fb-40a4-8404-e24a01b2220b", "e8da1e5e-838e-439a-8bca-f025d23e06b0" });
        }
    }
}
