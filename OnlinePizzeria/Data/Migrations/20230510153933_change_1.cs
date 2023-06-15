using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzeria.Migrations
{
    public partial class change_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId");
        }
    }
}
