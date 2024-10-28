﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrandaErick_P1.Migrations
{
    [DbContext(typeof(GrandaErickContext))]
    [Migration("20241028130904_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrandaErick_P1.Models.Celular", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Celular");
                });

            modelBuilder.Entity("GrandaErick_P1.Models.EGranda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Ecuatoriano")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDCelular")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("IDCelular");

                    b.ToTable("EGranda");
                });

            modelBuilder.Entity("GrandaErick_P1.Models.EGranda", b =>
                {
                    b.HasOne("GrandaErick_P1.Models.Celular", "Celular")
                        .WithMany()
                        .HasForeignKey("IDCelular")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celular");
                });
#pragma warning restore 612, 618
        }
    }
}