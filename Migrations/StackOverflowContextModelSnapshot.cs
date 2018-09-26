﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using stackoverflowclone;

namespace stackoverflowclone.Migrations
{
    [DbContext(typeof(StackOverflowContext))]
    partial class StackOverflowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("stackoverflowclone.Models.AnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("AnsweredBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DownVote");

                    b.Property<int>("QuestionId");

                    b.Property<int>("UpVote");

                    b.HasKey("Id");

                    b.ToTable("AnswersTable");
                });

            modelBuilder.Entity("stackoverflowclone.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnsweredBy");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DownVote");

                    b.Property<string>("Question");

                    b.Property<int>("UpVote");

                    b.HasKey("Id");

                    b.ToTable("QuestionsTable");
                });

            modelBuilder.Entity("stackoverflowclone.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("UserTable");
                });
#pragma warning restore 612, 618
        }
    }
}