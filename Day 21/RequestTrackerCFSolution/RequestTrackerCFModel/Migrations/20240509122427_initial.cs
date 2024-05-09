using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerCFModel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Rajini", "tigerkahukum" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Vijay", "anil" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Ajith", "ammai" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Ramu", "ramu123" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Somu", "somu123" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Bimu", "bimu123" });
        }
    }
}
