using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrtBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 1,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "readable", "content", "making", "web page", "content", "Lorem Ipsum is simply dummy text of the printing?" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 2,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "middle", "Hampden-Sydney", "undoubtable", "reproduced", "middle", "There are many variations of passages of Lorem Ipsum available" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 3,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "generate", "Ipsum", "therefore", "repetition", "Ipsum", "All the Lorem Ipsum generators on the Internet tend to repeat predefined" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 4,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "reproduced", "exact", "accompanied", "versions", "versions", "The standard chunk of Lorem Ipsum used since the" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 5,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "words", "standard", "popular", "repeat", "generate", "Lorem Ipsum comes from sections 1.10.32 and 1.10.33" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 1,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 2,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 3,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 4,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "QuestionId",
                keyValue: 5,
                columns: new[] { "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { "", "", "", "", "", "" });
        }
    }
}
