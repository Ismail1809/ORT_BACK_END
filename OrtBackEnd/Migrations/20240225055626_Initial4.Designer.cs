﻿// <auto-generated />
using System;
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
    [Migration("20240225055626_Initial4")]
    partial class Initial4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrtBackEnd.Models.CorrectAnswerModel", b =>
                {
                    b.Property<int>("CorrectAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CorrectAnswerId"));

                    b.Property<string>("AnswerText")
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("CorrectAnswerId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("CorrectAnswers");
                });

            modelBuilder.Entity("OrtBackEnd.Models.QuestionAnswerModel", b =>
                {
                    b.Property<int>("QuestionAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionAnswerId"));

                    b.Property<string>("AnswerText")
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionAnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("OrtBackEnd.Models.QuestionModel", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("QuestionText")
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OrtBackEnd.Models.User", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("StudentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrtBackEnd.Models.CorrectAnswerModel", b =>
                {
                    b.HasOne("OrtBackEnd.Models.QuestionModel", "QuestionModel")
                        .WithOne("CorrectAnswer")
                        .HasForeignKey("OrtBackEnd.Models.CorrectAnswerModel", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionModel");
                });

            modelBuilder.Entity("OrtBackEnd.Models.QuestionAnswerModel", b =>
                {
                    b.HasOne("OrtBackEnd.Models.QuestionModel", "QuestionModel")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionModel");
                });

            modelBuilder.Entity("OrtBackEnd.Models.QuestionModel", b =>
                {
                    b.Navigation("CorrectAnswer");

                    b.Navigation("QuestionAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
