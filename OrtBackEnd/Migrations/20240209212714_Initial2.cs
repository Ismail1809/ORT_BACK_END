using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OrtBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: true),
                    AnswerA = table.Column<string>(type: "text", nullable: true),
                    AnswerB = table.Column<string>(type: "text", nullable: true),
                    AnswerC = table.Column<string>(type: "text", nullable: true),
                    AnswerD = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { 1, "A", "B", "C", "D", null, "Question1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerA = table.Column<string>(type: "text", nullable: true),
                    AnswerB = table.Column<string>(type: "text", nullable: true),
                    AnswerC = table.Column<string>(type: "text", nullable: true),
                    AnswerD = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "text", nullable: true),
                    QuestionText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "QuestionId", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[] { 1, "A", "B", "C", "D", null, "Question1" });
        }
    }
}
