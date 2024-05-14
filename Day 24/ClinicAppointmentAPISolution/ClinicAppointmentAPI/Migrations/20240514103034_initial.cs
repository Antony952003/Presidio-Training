using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name", "Specialization" },
                values: new object[] { 101, 2.5, "Mark Zuckerberg", "ENT Specialist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name", "Specialization" },
                values: new object[] { 102, 1.5, "Elon Musk", "Orthodotist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
