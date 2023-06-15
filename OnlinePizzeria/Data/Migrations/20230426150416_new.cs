using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzeria.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PizzaSize",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaSize_Pizza_PizzaModelId",
                        column: x => x.PizzaModelId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaModelId");
                });

            migrationBuilder.CreateTable(
                name: "WeightOption",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Option = table.Column<int>(type: "int", nullable: false),
                    Products = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightOption_Pizza_PizzaModelId",
                        column: x => x.PizzaModelId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaModelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSize_PizzaModelId",
                table: "PizzaSize",
                column: "PizzaModelId",
                unique: true,
                filter: "[PizzaModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WeightOption_PizzaModelId",
                table: "WeightOption",
                column: "PizzaModelId",
                unique: true,
                filter: "[PizzaModelId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSize");

            migrationBuilder.DropTable(
                name: "WeightOption");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
