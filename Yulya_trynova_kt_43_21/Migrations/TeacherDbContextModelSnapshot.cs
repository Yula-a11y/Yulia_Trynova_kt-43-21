﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yulya_trynova_kt_43_21.Database;

#nullable disable

namespace Yulya_trynova_kt_43_21.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    partial class TeacherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Yulya_trynova_kt_43_21.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор записи дисциплины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("discipline_name")
                        .HasComment("Название дисциплины");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("f_teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("DisciplineId");

                    b.HasIndex("TeacherId");

                    b.ToTable("disciplines", (string)null);
                });

            modelBuilder.Entity("Yulya_trynova_kt_43_21.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор записи преподавателя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<int>("CathedraId")
                        .HasColumnType("int")
                        .HasColumnName("f_cathedra_id")
                        .HasComment("Идентификатор кафедры");

                    b.Property<string>("Degree")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("teacher_degree")
                        .HasComment("Ученая степень преподавателя");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("teacher_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("teacher_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("teacher_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("teacher_position")
                        .HasComment("Должность преподавателя");

                    b.HasKey("TeacherId");

                    b.HasIndex("CathedraId");

                    b.ToTable("teachers", (string)null);
                });

            modelBuilder.Entity("Yulya_trynova_kt_43_21.Models.Yulya_trynova_kt_43_21.Models.Cathedra", b =>
                {
                    b.Property<int>("CathedraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cathedra_id")
                        .HasComment("Идентификатор записи кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CathedraId"));

                    b.Property<int?>("HeadTeacherId")
                        .HasColumnType("int")
                        .HasColumnName("f_head_teacher_id")
                        .HasComment("Идентификатор заведующего кафедрой");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("cathedra_name")
                        .HasComment("Название кафедры");

                    b.HasKey("CathedraId");

                    b.ToTable("cathedras", (string)null);
                });

            modelBuilder.Entity("Yulya_trynova_kt_43_21.Models.Discipline", b =>
                {
                    b.HasOne("Yulya_trynova_kt_43_21.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Yulya_trynova_kt_43_21.Models.Teacher", b =>
                {
                    b.HasOne("Yulya_trynova_kt_43_21.Models.Yulya_trynova_kt_43_21.Models.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cathedra");
                });
#pragma warning restore 612, 618
        }
    }
}
