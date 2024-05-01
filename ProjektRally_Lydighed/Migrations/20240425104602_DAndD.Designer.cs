﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektRally_Lydighed.Data;

#nullable disable

namespace ProjektRally_Lydighed.Migrations
{
    [DbContext(typeof(ProjektRally_LydighedContext1))]
    [Migration("20240425104602_DAndD")]
    partial class DAndD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfExercise")
                        .HasColumnType("int");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseNr")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Sign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Rotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SignNumber")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<string>("XCoordinate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YCoordinate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrackId");

                    b.ToTable("Sign");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Exercise", b =>
                {
                    b.HasOne("ProjektRally_Lydighed.Models.Category", null)
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId");

                    b.HasOne("ProjektRally_Lydighed.Models.Equipment", "Equipment")
                        .WithMany("Exercises")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Sign", b =>
                {
                    b.HasOne("ProjektRally_Lydighed.Models.Exercise", "Exercise")
                        .WithMany("Signs")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektRally_Lydighed.Models.Track", "Track")
                        .WithMany("Signs")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Track", b =>
                {
                    b.HasOne("ProjektRally_Lydighed.Models.Category", "Category")
                        .WithMany("Tracks")
                        .HasForeignKey("CategoryId");

                    b.HasOne("ProjektRally_Lydighed.Models.User", null)
                        .WithMany("Tracks")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Category", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Equipment", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Exercise", b =>
                {
                    b.Navigation("Signs");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.Track", b =>
                {
                    b.Navigation("Signs");
                });

            modelBuilder.Entity("ProjektRally_Lydighed.Models.User", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}