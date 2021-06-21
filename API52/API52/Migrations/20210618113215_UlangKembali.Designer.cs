﻿// <auto-generated />
using System;
using API52.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API52.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210618113215_UlangKembali")]
    partial class UlangKembali
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API52.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_M_Account");
                });

            modelBuilder.Entity("API52.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("EducationId");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_M_Education");
                });

            modelBuilder.Entity("API52.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_M_Employee");
                });

            modelBuilder.Entity("API52.Models.Profilling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EducationId");

                    b.ToTable("tb_M_Profilling");
                });

            modelBuilder.Entity("API52.Models.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniversityId");

                    b.ToTable("tb_M_University");
                });

            modelBuilder.Entity("API52.Models.Account", b =>
                {
                    b.HasOne("API52.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("API52.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API52.Models.Education", b =>
                {
                    b.HasOne("API52.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("API52.Models.Profilling", b =>
                {
                    b.HasOne("API52.Models.Education", "Education")
                        .WithMany("Profillings")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API52.Models.Account", "Account")
                        .WithOne("Profilling")
                        .HasForeignKey("API52.Models.Profilling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("API52.Models.Account", b =>
                {
                    b.Navigation("Profilling");
                });

            modelBuilder.Entity("API52.Models.Education", b =>
                {
                    b.Navigation("Profillings");
                });

            modelBuilder.Entity("API52.Models.Employee", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("API52.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
