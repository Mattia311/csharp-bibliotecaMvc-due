﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharp_bibliotecaMvc.Data;

#nullable disable

namespace csharp_bibliotecaMvc_due.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    [Migration("20220613122248_FirstCreate")]
    partial class FirstCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutoriLibro", b =>
                {
                    b.Property<int>("AutoriAutoreId")
                        .HasColumnType("int");

                    b.Property<int>("LibroID")
                        .HasColumnType("int");

                    b.HasKey("AutoriAutoreId", "LibroID");

                    b.HasIndex("LibroID");

                    b.ToTable("AutoriLibro");
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Autori", b =>
                {
                    b.Property<int>("AutoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoreId"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutoreId");

                    b.ToTable("Autore", (string)null);
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Libro", b =>
                {
                    b.Property<int>("LibroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibroID"), 1L, 1);

                    b.Property<string>("Scaffale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Settore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stato")
                        .HasColumnType("int");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibroID");

                    b.ToTable("Libro", (string)null);
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Prestito", b =>
                {
                    b.Property<int>("PrestitoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Al")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dal")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibroID")
                        .HasColumnType("int");

                    b.Property<int>("UtenteID")
                        .HasColumnType("int");

                    b.HasKey("PrestitoID");

                    b.HasIndex("LibroID")
                        .IsUnique();

                    b.HasIndex("UtenteID");

                    b.ToTable("Prestito", (string)null);
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Utente", b =>
                {
                    b.Property<int>("UtenteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtenteID"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UtenteID");

                    b.ToTable("Utente", (string)null);
                });

            modelBuilder.Entity("AutoriLibro", b =>
                {
                    b.HasOne("csharp_bibliotecaMvc.Models.Autori", null)
                        .WithMany()
                        .HasForeignKey("AutoriAutoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_bibliotecaMvc.Models.Libro", null)
                        .WithMany()
                        .HasForeignKey("LibroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Prestito", b =>
                {
                    b.HasOne("csharp_bibliotecaMvc.Models.Libro", "Libro")
                        .WithOne("Prestito")
                        .HasForeignKey("csharp_bibliotecaMvc.Models.Prestito", "LibroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_bibliotecaMvc.Models.Utente", "Utente")
                        .WithMany("Prestito")
                        .HasForeignKey("UtenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");

                    b.Navigation("Utente");
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Libro", b =>
                {
                    b.Navigation("Prestito");
                });

            modelBuilder.Entity("csharp_bibliotecaMvc.Models.Utente", b =>
                {
                    b.Navigation("Prestito");
                });
#pragma warning restore 612, 618
        }
    }
}
