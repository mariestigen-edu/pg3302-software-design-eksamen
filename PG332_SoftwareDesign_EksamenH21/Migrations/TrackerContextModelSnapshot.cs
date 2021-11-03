﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    [DbContext(typeof(TrackerContext))]
    partial class TrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("LectureDateTime")
                        .HasColumnType("TEXT");

                    b.Property<long?>("TaskSetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TaskSetId");

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

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("TaskSetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskSetId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.TaskSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaskSets");
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

                    b.HasOne("PG332_SoftwareDesign_EksamenH21.TaskSet", "TaskSet")
                        .WithMany()
                        .HasForeignKey("TaskSetId");

                    b.Navigation("TaskSet");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Task", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.TaskSet", null)
                        .WithMany("Tasks")
                        .HasForeignKey("TaskSetId");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.TaskSet", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
