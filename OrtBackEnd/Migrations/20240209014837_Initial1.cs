using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrtBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "QuestionId", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { 1, "A", "B", "C", "D", null, "Question1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 1);
        }
    }
}
