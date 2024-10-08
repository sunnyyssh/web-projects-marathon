﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz.Host.Model;

#nullable disable

namespace Quiz.Host.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quiz.Model.QuestionCorrectAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AnswerIndex")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<int?>("QuizCorrectAnswersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.HasIndex("QuizCorrectAnswersId");

                    b.ToTable("QuestionCorrectAnswers");
                });

            modelBuilder.Entity("Quiz.Model.QuestionInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("QuizInfoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuizInfoId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quiz.Model.QuizCorrectAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuizId")
                        .IsUnique();

                    b.ToTable("QuizCorrectAnswers");
                });

            modelBuilder.Entity("Quiz.Model.QuizInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Quiz.Model.QuestionCorrectAnswer", b =>
                {
                    b.HasOne("Quiz.Model.QuestionInfo", "QuestionInfo")
                        .WithOne("CorrectAnswer")
                        .HasForeignKey("Quiz.Model.QuestionCorrectAnswer", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Model.QuizCorrectAnswers", null)
                        .WithMany("AnswersMap")
                        .HasForeignKey("QuizCorrectAnswersId");

                    b.Navigation("QuestionInfo");
                });

            modelBuilder.Entity("Quiz.Model.QuestionInfo", b =>
                {
                    b.HasOne("Quiz.Model.QuizInfo", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizInfoId");
                });

            modelBuilder.Entity("Quiz.Model.QuizCorrectAnswers", b =>
                {
                    b.HasOne("Quiz.Model.QuizInfo", "Quiz")
                        .WithOne("CorrectAnswers")
                        .HasForeignKey("Quiz.Model.QuizCorrectAnswers", "QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quiz.Model.QuestionInfo", b =>
                {
                    b.Navigation("CorrectAnswer");
                });

            modelBuilder.Entity("Quiz.Model.QuizCorrectAnswers", b =>
                {
                    b.Navigation("AnswersMap");
                });

            modelBuilder.Entity("Quiz.Model.QuizInfo", b =>
                {
                    b.Navigation("CorrectAnswers");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
