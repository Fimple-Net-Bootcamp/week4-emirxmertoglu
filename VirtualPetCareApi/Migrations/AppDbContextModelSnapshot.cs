﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VirtualPetCareApi.Data;

#nullable disable

namespace VirtualPetCareApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VirtualPetCareApi.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.HealthStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("HealthStatuses");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Activity", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithMany("Activities")
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Food", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.HealthStatus", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithOne("HealthStatus")
                        .HasForeignKey("VirtualPetCareApi.Models.HealthStatus", "PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("HealthStatus");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.User", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
