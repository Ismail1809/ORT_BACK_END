using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrtBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
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
                    table.PrimaryKey("PK_Test", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "QuestionId", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "QuestionText" },
                values: new object[,]
                {
                    { 1, "", "", "", "", "", "" },
                    { 2, "", "", "", "", "", "" },
                    { 3, "", "", "", "", "", "" },
                    { 4, "", "", "", "", "", "" },
                    { 5, "", "", "", "", "", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
