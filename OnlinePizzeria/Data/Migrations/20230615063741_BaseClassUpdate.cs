using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzeria.Migrations
{
    public partial class BaseClassUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d1b23c3-3621-48d2-a540-236c307df69e", "e9e0804c-fd82-45e4-883f-8766672824f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "116156df-ce22-4d04-b456-f897f0bd38aa", "f04479fc-581d-4f7d-95cd-4dfe01f594ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "116156df-ce22-4d04-b456-f897f0bd38aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d1b23c3-3621-48d2-a540-236c307df69e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9e0804c-fd82-45e4-883f-8766672824f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f04479fc-581d-4f7d-95cd-4dfe01f594ee");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Pizza",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "OnlinePayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "CustomPizzas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "OnlinePayment");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CustomPizzas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "116156df-ce22-4d04-b456-f897f0bd38aa", "6d883265-0f79-4a38-960f-c0ffbc0e12a3", new DateTime(2023, 6, 14, 14, 30, 6, 523, DateTimeKind.Local).AddTicks(8716), "User", "USER" },
                    { "3d1b23c3-3621-48d2-a540-236c307df69e", "4623508c-6039-4324-808d-7f5db6c31191", new DateTime(2023, 6, 14, 14, 30, 6, 523, DateTimeKind.Local).AddTicks(8621), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicturePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e9e0804c-fd82-45e4-883f-8766672824f7", 0, "38785ad2-bafd-4925-8912-fbb581d09d81", new DateTime(2023, 6, 14, 14, 30, 6, 523, DateTimeKind.Local).AddTicks(8809), "a@admin.com", true, new DateTime(2023, 6, 14, 14, 30, 6, 523, DateTimeKind.Local).AddTicks(8812), false, null, null, "A@ADMIN.COM", "PETAR", "AQAAAAEAACcQAAAAELm5gG4GFHSlQF65CuC0ShqhQj3ZYkVVRB4FBHuKWweIWb504s46abROoCnmj5jhtg==", null, false, "/ProfilePictures/default.jpg", "262d2e8e-1895-4f43-b7b6-1b7281887729", false, "Petar" },
                    { "f04479fc-581d-4f7d-95cd-4dfe01f594ee", 0, "0783d8ec-b1dc-4e4f-b33d-1606c22f5dee", new DateTime(2023, 6, 14, 14, 30, 6, 525, DateTimeKind.Local).AddTicks(4867), "u@user.com", true, new DateTime(2023, 6, 14, 14, 30, 6, 525, DateTimeKind.Local).AddTicks(4897), false, null, null, "U@USER.COM", "GEORGI", "AQAAAAEAACcQAAAAENd438kT1g0qLpOzKaRVr7+itlJrv9WZ/2k8njVk5FyJMoY570+Ok0mJ0ySehynY5g==", null, false, "/ProfilePictures/default.jpg", "7971cd7e-7fd8-4fea-95de-0d8c5c713a82", false, "Georgi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d1b23c3-3621-48d2-a540-236c307df69e", "e9e0804c-fd82-45e4-883f-8766672824f7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "116156df-ce22-4d04-b456-f897f0bd38aa", "f04479fc-581d-4f7d-95cd-4dfe01f594ee" });
        }
    }
}
