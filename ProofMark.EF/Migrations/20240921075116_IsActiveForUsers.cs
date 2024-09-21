using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProofMark.EF.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20027554-fd43-47c5-a973-15a38ae5bc72");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57377347-8b55-4401-9132-58de8b30b55f", "4cfc5828-5d6a-4f02-b19e-a3483bf30747" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57377347-8b55-4401-9132-58de8b30b55f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cfc5828-5d6a-4f02-b19e-a3483bf30747");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20027554-fd43-47c5-a973-15a38ae5bc72", null, "Factory", "FACTORY" },
                    { "57377347-8b55-4401-9132-58de8b30b55f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "4cfc5828-5d6a-4f02-b19e-a3483bf30747", 0, "528c4e4e-c11e-4607-a558-0e12f182cd26", new DateTime(2024, 9, 20, 17, 36, 13, 958, DateTimeKind.Local).AddTicks(786), "Admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAMoEtOPATybfh8dvqLSEzcDoLV20rARwwz++vLTS1ROyxsT+rve/wxoiU1VMvG0Xw==", "1234567890", false, "811349a5-940c-4cd4-92e4-c7e67f5eba42", false, "Admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57377347-8b55-4401-9132-58de8b30b55f", "4cfc5828-5d6a-4f02-b19e-a3483bf30747" });
        }
    }
}
