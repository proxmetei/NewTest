﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewTest.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewTest.Context.Migrations.PgSql.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20240926204329_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NewTest.Context.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("answers", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("interviews", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("questions", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<int>("InterviewId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("InterviewId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("results", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("surveys", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.SurveyQuestionNumber", b =>
                {
                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("SurveyId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("survey_question", (string)null);
                });

            modelBuilder.Entity("NewTest.Context.Entities.Answer", b =>
                {
                    b.HasOne("NewTest.Context.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Interview", b =>
                {
                    b.HasOne("NewTest.Context.Entities.Survey", "Survey")
                        .WithMany("Interviews")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Result", b =>
                {
                    b.HasOne("NewTest.Context.Entities.Answer", "Answer")
                        .WithMany("Results")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NewTest.Context.Entities.Interview", "Interview")
                        .WithMany("Results")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("NewTest.Context.Entities.SurveyQuestionNumber", b =>
                {
                    b.HasOne("NewTest.Context.Entities.Question", "Question")
                        .WithMany("SurveyQuestionNumbers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewTest.Context.Entities.Survey", "Survey")
                        .WithMany("SurveyQuestionNumbers")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Answer", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Interview", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("SurveyQuestionNumbers");
                });

            modelBuilder.Entity("NewTest.Context.Entities.Survey", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("SurveyQuestionNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
