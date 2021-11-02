﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20211102134236_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("CoursePoints")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamType")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Lecture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("LectureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Semester", null)
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Lecture", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Course", null)
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Task", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
