﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tryitter.Repository;

#nullable disable

namespace Tryitter.Migrations
{
  [DbContext(typeof(TryitterContext))]
  [Migration("20221103173952_ModuloModel")]
  partial class ModuloModel
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "6.0.10")
          .HasAnnotation("Relational:MaxIdentifierLength", 128);

      SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

      modelBuilder.Entity("Tryitter.Model.modulos", b =>
          {
            b.Property<int>("ModuloId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuloId"), 1L, 1);

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("ModuloId");

            b.ToTable("modulos");

            b.HasData(
                      new
                      {
                        ModuloId = 1,
                        Name = "Fundamentos"
                      },
                      new
                      {
                        ModuloId = 2,
                        Name = "Front-end"
                      },
                      new
                      {
                        ModuloId = 3,
                        Name = "Back-end"
                      },
                      new
                      {
                        ModuloId = 4,
                        Name = "Ciência da Computação"
                      });
          });

      modelBuilder.Entity("Tryitter.Model.PostModel", b =>
          {
            b.Property<int>("PostId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

            b.Property<string>("Content")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<int>("Likes")
                      .HasColumnType("int");

            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.HasKey("PostId");

            b.HasIndex("UserId");

            b.ToTable("posts");
          });

      modelBuilder.Entity("Tryitter.Model.UserModel", b =>
          {
            b.Property<int>("UserId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

            b.Property<string>("Arroba")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<string>("Email")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Img")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("ModuloId")
                      .HasColumnType("int");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Password")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("UserId");

            b.HasIndex("ModuloId");

            b.ToTable("users");
          });

      modelBuilder.Entity("Tryitter.Model.PostModel", b =>
          {
            b.HasOne("Tryitter.Model.UserModel", "User")
                      .WithMany("Posts")
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("User");
          });

      modelBuilder.Entity("Tryitter.Model.UserModel", b =>
          {
            b.HasOne("Tryitter.Model.modulos", "Modulo")
                      .WithMany()
                      .HasForeignKey("ModuloId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Modulo");
          });

      modelBuilder.Entity("Tryitter.Model.UserModel", b =>
          {
            b.Navigation("Posts");
          });
#pragma warning restore 612, 618
    }
  }
}
