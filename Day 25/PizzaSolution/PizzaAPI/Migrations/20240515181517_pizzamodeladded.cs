using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAPI.Migrations
{
    public partial class pizzamodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "AvailableStock", "Description", "Name", "Status" },
                values: new object[] { 101, 4, "Pizza topped with our herb infused signature", "Margherita Pizza", true });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "AvailableStock", "Description", "Name", "Status" },
                values: new object[] { 102, 3, "Spiciest non veg pizza with spicy & herby chicken sausage and red paprika toppings on a new spicy peri peri sauce base.", "Fiery Sausage & Paprika Pizza", true });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "AvailableStock", "Description", "Name", "Status" },
                values: new object[] { 103, 8, "Delightful combination of our spicy duo- Pepper Barbecue Chicken and Peri Peri Chicken for Chicken Lovers.", "Spiced Double Chicken Pizza", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
