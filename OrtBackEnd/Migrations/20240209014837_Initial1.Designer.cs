﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrtBackEnd.DatabaseContext;

#nullable disable

namespace OrtBackEnd.Migrations
{
    [DbContext(typeof(QuestionsDb))]
    [Migration("20240209014837_Initial1")]
    partial class Initial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrtBackEnd.Models.Test", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("AnswerA")
                        .HasColumnType("text");

                    b.Property<string>("AnswerB")
                        .HasColumnType("text");

                    b.Property<string>("AnswerC")
                        .HasColumnType("text");

                    b.Property<string>("AnswerD")
                        .HasColumnType("text");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.ToTable("Test");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            AnswerA = "A",
                            AnswerB = "B",
                            AnswerC = "C",
                            AnswerD = "D",
                            QuestionText = "Question1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
