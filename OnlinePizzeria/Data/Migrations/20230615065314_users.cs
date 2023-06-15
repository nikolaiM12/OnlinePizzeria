using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzeria.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ce2c1b15-86fe-4ce9-b6ac-4c6823bff988", "7314d211-018f-402b-9c98-6d38e8bbcd3c", new DateTime(2023, 6, 15, 9, 53, 14, 74, DateTimeKind.Local).AddTicks(6597), "Admin", "ADMIN" },
                    { "f8988f73-dc5b-4f93-b874-d9875d6d5849", "5c827e41-3bfc-491d-9f32-906b9e65c6db", new DateTime(2023, 6, 15, 9, 53, 14, 74, DateTimeKind.Local).AddTicks(6699), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicturePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "555d034b-a6bd-46b9-a67c-b5e9884f7fd2", 0, "63fcfeda-d658-4080-8726-86a289d32a41", new DateTime(2023, 6, 15, 9, 53, 14, 74, DateTimeKind.Local).AddTicks(6784), "a@admin.com", true, new DateTime(2023, 6, 15, 9, 53, 14, 74, DateTimeKind.Local).AddTicks(6787), false, null, null, "A@ADMIN.COM", "PETAR", "AQAAAAEAACcQAAAAEDZCevkjggRxs4NWp+0dzB1dU9QmHSazGnOu487bLvEVYU9XpKu43cQoi3Uyhn2Qvw==", null, false, "/ProfilePictures/default.jpg", "27e644a5-7fb3-46b4-bf22-b3bad4cdfe79", false, "Petar" },
                    { "afcd4ee3-c6b5-4fd7-8136-8003f664c496", 0, "64bb6f45-272a-404c-b7c0-2d3b7b50bff0", new DateTime(2023, 6, 15, 9, 53, 14, 77, DateTimeKind.Local).AddTicks(5801), "u@user.com", true, new DateTime(2023, 6, 15, 9, 53, 14, 77, DateTimeKind.Local).AddTicks(5831), false, null, null, "U@USER.COM", "GEORGI", "AQAAAAEAACcQAAAAEDw1q/h5fDf1CBm3iIP6Tc5C4Pp4yUz3KPNLi6ro27bc+b36fVz5zt9LpVWrNKNy7w==", null, false, "/ProfilePictures/default.jpg", "6b5e9ba3-a42e-44ab-9121-e423abd64d98", false, "Georgi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce2c1b15-86fe-4ce9-b6ac-4c6823bff988", "555d034b-a6bd-46b9-a67c-b5e9884f7fd2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8988f73-dc5b-4f93-b874-d9875d6d5849", "afcd4ee3-c6b5-4fd7-8136-8003f664c496" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce2c1b15-86fe-4ce9-b6ac-4c6823bff988", "555d034b-a6bd-46b9-a67c-b5e9884f7fd2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8988f73-dc5b-4f93-b874-d9875d6d5849", "afcd4ee3-c6b5-4fd7-8136-8003f664c496" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2c1b15-86fe-4ce9-b6ac-4c6823bff988");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8988f73-dc5b-4f93-b874-d9875d6d5849");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "555d034b-a6bd-46b9-a67c-b5e9884f7fd2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afcd4ee3-c6b5-4fd7-8136-8003f664c496");
        }
    }
}
