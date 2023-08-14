﻿// <auto-generated />
using System;
using AdaSigortaAppYeniWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdaSigortaAppYeniWebApi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Dask", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyId"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<double?>("Prim")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanzimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBitis")
                        .HasColumnType("datetime2");

                    b.HasKey("PolicyId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("Dask");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KimlikNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Traffic", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyId"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PlakaIlKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlakaKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Prim")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanzimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBitis")
                        .HasColumnType("datetime2");

                    b.HasKey("PolicyId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("Trafik");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Dask", b =>
                {
                    b.HasOne("AdaSigortaAppYeniWebApi.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("AdaSigortaAppYeniWebApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Person");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AdaSigortaAppYeniWebApi.Models.Traffic", b =>
                {
                    b.HasOne("AdaSigortaAppYeniWebApi.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("AdaSigortaAppYeniWebApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Person");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
