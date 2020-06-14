﻿// <auto-generated />
using System;
using BarDG.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BarDG.Repository.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20200614210307_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("BarDG.Domain.Entity.Comanda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.NotaFiscal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalDesconto")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NotaFiscals");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ComandaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("NotaFiscalId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef91528e-d3e9-450e-a75a-4b35e0ae8df2"),
                            Descricao = "Cerveja",
                            Valor = 5m
                        },
                        new
                        {
                            Id = new Guid("22bf78e3-5dfc-4444-a7fd-f30e4e0c2ea4"),
                            Descricao = "Conhaque",
                            Valor = 20m
                        },
                        new
                        {
                            Id = new Guid("5cb07a8d-dc78-49d3-a494-95e54630c6bc"),
                            Descricao = "Suco",
                            Valor = 50m
                        },
                        new
                        {
                            Id = new Guid("5386c928-176e-42e2-a431-0b4cc70c405b"),
                            Descricao = "Água",
                            Valor = 70m
                        });
                });

            modelBuilder.Entity("BarDG.Domain.Entity.Produto", b =>
                {
                    b.HasOne("BarDG.Domain.Entity.Comanda", null)
                        .WithMany("Produtos")
                        .HasForeignKey("ComandaId");

                    b.HasOne("BarDG.Domain.Entity.NotaFiscal", null)
                        .WithMany("Produtos")
                        .HasForeignKey("NotaFiscalId");
                });
#pragma warning restore 612, 618
        }
    }
}