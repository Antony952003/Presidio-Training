using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class requestmodeladdedwithfKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RaisedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RaisedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RaisedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RaisedByEmployeeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestClosedByEmployeeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RaisedByEmployeeId",
                table: "Requests",
                column: "RaisedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests",
                column: "RequestClosedByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RaisedByEmployeeId",
                table: "Requests",
                column: "RaisedByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedByEmployeeId",
                table: "Requests",
                column: "RequestClosedByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
