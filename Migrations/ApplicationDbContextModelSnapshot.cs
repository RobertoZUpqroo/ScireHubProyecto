﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScireHub.Context;

#nullable disable

namespace ScireHub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScireHub.Models.Entities.Investigación", b =>
                {
                    b.Property<int>("PkInvestigación")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkInvestigación"));

                    b.Property<string>("Categoría")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkAutor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPdfPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkInvestigación");

                    b.HasIndex("FkAutor");

                    b.ToTable("Investigaciones");
                });

            modelBuilder.Entity("ScireHub.Models.Entities.Rol", b =>
                {
                    b.Property<int>("PkRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRoles"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRoles");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ScireHub.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("PKUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKUsuario"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImagenPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PKUsuario = 1,
                            Apellido1 = "Fierro",
                            Apellido2 = "Ballote",
                            Contraseña = "1234",
                            Correo = "robertojunio2004@gmail.com",
                            Nombre = "Roberto",
                            NombreUsuario = "robertofb"
                        });
                });

            modelBuilder.Entity("ScireHub.Models.Entities.Investigación", b =>
                {
                    b.HasOne("ScireHub.Models.Entities.Usuario", "Autores")
                        .WithMany()
                        .HasForeignKey("FkAutor");

                    b.Navigation("Autores");
                });

            modelBuilder.Entity("ScireHub.Models.Entities.Usuario", b =>
                {
                    b.HasOne("ScireHub.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
