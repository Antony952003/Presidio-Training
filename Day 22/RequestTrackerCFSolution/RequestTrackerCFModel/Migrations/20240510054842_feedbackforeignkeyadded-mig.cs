using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerCFModel.Migrations
{
    public partial class feedbackforeignkeyaddedmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackByEmployeeId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_FeedbackByEmployeeId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackByEmployeeId",
                table: "Feedbacks");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackBy",
                table: "Feedbacks",
                column: "FeedbackBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackBy",
                table: "Feedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackBy",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_FeedbackBy",
                table: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackByEmployeeId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackByEmployeeId",
                table: "Feedbacks",
                column: "FeedbackByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackByEmployeeId",
                table: "Feedbacks",
                column: "FeedbackByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
