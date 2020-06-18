﻿// <auto-generated />
using System;
using BarDG.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BarDG.Repository.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("BarDG.Domain.Entity.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.ComandaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComandaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Desconto")
                        .HasColumnType("REAL");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.NotaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NotaFiscais");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.NotaFiscalItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Desconto")
                        .HasColumnType("REAL");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NotaFiscalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("NotaFiscalItens");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraMaxima")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Desconto")
                        .HasColumnType("REAL");

                    b.Property<bool>("DescontoMaximo")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemDescontoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RepetirPromocao")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemDescontoId");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.PromocaoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PromocaoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PromocaoId");

                    b.ToTable("PromocaoItens");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.ComandaItem", b =>
                {
                    b.HasOne("BarDG.Domain.Entity.Comanda", null)
                        .WithMany("Itens")
                        .HasForeignKey("ComandaId");

                    b.HasOne("BarDG.Domain.Entity.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.NotaFiscalItem", b =>
                {
                    b.HasOne("BarDG.Domain.Entity.NotaFiscal", null)
                        .WithMany("Itens")
                        .HasForeignKey("NotaFiscalId");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.Promocao", b =>
                {
                    b.HasOne("BarDG.Domain.Entity.Produto", "ItemDesconto")
                        .WithMany()
                        .HasForeignKey("ItemDescontoId");
                });

            modelBuilder.Entity("BarDG.Domain.Entity.PromocaoItem", b =>
                {
                    b.HasOne("BarDG.Domain.Entity.Produto", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("BarDG.Domain.Entity.Promocao", null)
                        .WithMany("ItensAtivadores")
                        .HasForeignKey("PromocaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
