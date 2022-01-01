﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineQuizApi.Models;

namespace OnlineQuizApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220101064650_init migrations")]
    partial class initmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineQuizApi.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Title = "C#"
                        },
                        new
                        {
                            CategoryId = 2,
                            Title = "MsSQL"
                        },
                        new
                        {
                            CategoryId = 3,
                            Title = "ASP.Net Core"
                        });
                });

            modelBuilder.Entity("OnlineQuizApi.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CorrAns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CorrAns = "C int a = 32; int b = 40;",
                            Option1 = "A int a = 32, b = 40.6;",
                            Option2 = "B int a = 42; b = 40;",
                            Option3 = "C int a = 32; int b = 40;",
                            Option4 = "D int a = b = 42;",
                            Question = "Correct Declaration of Values to variables a and b?"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CorrAns = "8",
                            Option1 = "8",
                            Option2 = "4",
                            Option3 = "2",
                            Option4 = "1",
                            Question = "How many Bytes are stored by Long Datatype in C# .net?"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CorrAns = "Data Manipulation Language(DML)",
                            Option1 = "Data Manipulation Language(DML)",
                            Option2 = "Data Definition Language(DDL)",
                            Option3 = "Both Of Above",
                            Option4 = "None",
                            Question = "Which Is The Subset Of SQL Commands Used To Manipulate Oracle Database Structures, Including Tables?"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CorrAns = "2345",
                            Option1 = "6789",
                            Option2 = "1234",
                            Option3 = "2345",
                            Option4 = "456789",
                            Question = "The SQL Statement<br>SELECT SUBSTR('123456789', INSTR('abcabcabc', 'b'), 4) FROM DUAL;"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CorrAns = "LCID",
                            Option1 = "LCID",
                            Option2 = "SessionId",
                            Option3 = "Key",
                            Option4 = "Item",
                            Question = "Which property of the session object is used to set the local identifier?"
                        });
                });

            modelBuilder.Entity("OnlineQuizApi.Models.Questions", b =>
                {
                    b.HasOne("OnlineQuizApi.Models.Categories", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}