﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebProgrammingProject.Models.db;

#nullable disable

namespace WebProgrammingProject.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20241127155234_First_Migration")]
    partial class First_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebProgrammingProject.Models.db.AvailableTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("availableTimeSpan")
                        .HasColumnType("interval");

                    b.Property<DateTime>("end_t")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("start_t")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.ToTable("AvailableTime_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Barber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("integer");

                    b.Property<int?>("ShopId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.HasIndex("ShopId");

                    b.ToTable("Barber_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Customer_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Person_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Rendezvous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("When")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rendezvous_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShopkeeperId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShopkeeperId");

                    b.ToTable("Shop_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shopkeeper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Shopkeeper_t");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.AvailableTime", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Barber", "Barber")
                        .WithMany("AvailableTimes")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Barber", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Person", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProgrammingProject.Models.db.Shop", null)
                        .WithMany("Barbers")
                        .HasForeignKey("ShopId");

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Customer", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Person", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Rendezvous", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Barber", "Barber")
                        .WithMany("Rendezvous")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProgrammingProject.Models.db.Customer", "Customer")
                        .WithMany("Rendezvous")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shop", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Shopkeeper", "Shopkeeper")
                        .WithMany("Shops")
                        .HasForeignKey("ShopkeeperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shopkeeper");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shopkeeper", b =>
                {
                    b.HasOne("WebProgrammingProject.Models.db.Person", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Barber", b =>
                {
                    b.Navigation("AvailableTimes");

                    b.Navigation("Rendezvous");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Customer", b =>
                {
                    b.Navigation("Rendezvous");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shop", b =>
                {
                    b.Navigation("Barbers");
                });

            modelBuilder.Entity("WebProgrammingProject.Models.db.Shopkeeper", b =>
                {
                    b.Navigation("Shops");
                });
#pragma warning restore 612, 618
        }
    }
}
