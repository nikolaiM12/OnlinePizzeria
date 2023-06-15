using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzeria.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlinePayment_Orders_OrderId",
                table: "OnlinePayment");

            migrationBuilder.DropColumn(
                name: "IsDelivered",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PizzaModelId",
                table: "Pizza",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditCardPaymentId",
                table: "OnlinePayment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Providers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizza",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Pizza",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Pizza",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "OnlinePayment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OnlinePayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CustomPizzas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    TomatoSauce = table.Column<bool>(type: "bit", nullable: false),
                    Cheese = table.Column<bool>(type: "bit", nullable: false),
                    Peperoni = table.Column<bool>(type: "bit", nullable: false),
                    Mushroom = table.Column<bool>(type: "bit", nullable: false),
                    Tuna = table.Column<bool>(type: "bit", nullable: false),
                    Pineapple = table.Column<bool>(type: "bit", nullable: false),
                    Ham = table.Column<bool>(type: "bit", nullable: false),
                    Beef = table.Column<bool>(type: "bit", nullable: false),
                    FinalPrice = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomPizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPizzas_OrderId",
                table: "CustomPizzas",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlinePayment_Orders_OrderId",
                table: "OnlinePayment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlinePayment_Orders_OrderId",
                table: "OnlinePayment");

            migrationBuilder.DropTable(
                name: "CustomPizzas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OnlinePayment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pizza",
                newName: "PizzaModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OnlinePayment",
                newName: "CreditCardPaymentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelivered",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "OnlinePayment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlinePayment_Orders_OrderId",
                table: "OnlinePayment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
