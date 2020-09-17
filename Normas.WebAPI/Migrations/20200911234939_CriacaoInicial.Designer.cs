﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Normas.WebAPI.Data;

namespace Normas.WebAPI.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200911234939_CriacaoInicial")]
    partial class CriacaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Normas.WebAPI.Entities.Norma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoNorma")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("IdOrgaoExpedidor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoDocumento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocalArquivoNormas")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Resumo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CodigoNorma")
                        .IsUnique();

                    b.HasIndex("IdOrgaoExpedidor");

                    b.HasIndex("IdTipoDocumento");

                    b.ToTable("NORMA");
                });

            modelBuilder.Entity("Normas.WebAPI.Entities.OrgaoExpedidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ORGAOEXPEDIDOR");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Indefinido"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "ABNT"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "ISO"
                        });
                });

            modelBuilder.Entity("Normas.WebAPI.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TIPODOCUMENTO");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Indefinido"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Norma de Base"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Norma de Terminologia"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Norma de Ensaio"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Norma de Produto"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Norma de Processo"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Norma de Serviço"
                        });
                });

            modelBuilder.Entity("Normas.WebAPI.Entities.Norma", b =>
                {
                    b.HasOne("Normas.WebAPI.Entities.OrgaoExpedidor", "OrgaoExpedidor")
                        .WithMany("Normas")
                        .HasForeignKey("IdOrgaoExpedidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Normas.WebAPI.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Normas")
                        .HasForeignKey("IdTipoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}