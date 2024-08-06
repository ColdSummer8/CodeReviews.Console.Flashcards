﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240806072825_AddPropertyToEntityStudy")]
    partial class AddPropertyToEntityStudy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Flashcard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StackID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Question")
                        .IsUnique();

                    b.HasIndex("StackID");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("Model.FlashcardDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StackID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("FlashcardsDTO");
                });

            modelBuilder.Entity("Model.Stack", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasAlternateKey("Name");

                    b.ToTable("Stacks");
                });

            modelBuilder.Entity("Model.StackDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StacksDTO");
                });

            modelBuilder.Entity("Model.Study", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Attempt")
                        .HasColumnType("int")
                        .HasColumnName("Attempted Questions");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StackID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StackID");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("Model.Flashcard", b =>
                {
                    b.HasOne("Model.Stack", "Stacks")
                        .WithMany("Flashcards")
                        .HasForeignKey("StackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stacks");
                });

            modelBuilder.Entity("Model.Study", b =>
                {
                    b.HasOne("Model.Stack", "Stacks")
                        .WithMany("Studies")
                        .HasForeignKey("StackID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stacks");
                });

            modelBuilder.Entity("Model.Stack", b =>
                {
                    b.Navigation("Flashcards");

                    b.Navigation("Studies");
                });
#pragma warning restore 612, 618
        }
    }
}
