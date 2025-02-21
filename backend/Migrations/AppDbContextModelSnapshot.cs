﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Compras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PecaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecoCusto")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PecaId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("backend.Models.Entrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("backend.Models.MovimentacaoEstoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PecaId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("tipoMovimentacao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PecaId");

                    b.ToTable("MovimentacoesEstoque");
                });

            modelBuilder.Entity("backend.Models.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NameCliente")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("backend.Models.OrcamentoPecas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("PecaId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("PecaId");

                    b.ToTable("OrcamentoPecas");
                });

            modelBuilder.Entity("backend.Models.Peca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Estoque")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Pecas");
                });

            modelBuilder.Entity("backend.Models.Compras", b =>
                {
                    b.HasOne("backend.Models.Peca", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("backend.Models.Entrega", b =>
                {
                    b.HasOne("backend.Models.Orcamento", "Orcamento")
                        .WithMany()
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("backend.Models.MovimentacaoEstoque", b =>
                {
                    b.HasOne("backend.Models.Peca", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("backend.Models.OrcamentoPecas", b =>
                {
                    b.HasOne("backend.Models.Orcamento", "Orcamento")
                        .WithMany("Pecas")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Models.Peca", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("backend.Models.Orcamento", b =>
                {
                    b.Navigation("Pecas");
                });
#pragma warning restore 612, 618
        }
    }
}
