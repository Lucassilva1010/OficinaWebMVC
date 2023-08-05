﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OficinaWebMVC.Database.Contexto;

#nullable disable

namespace OficinaWebMVC.Migrations
{
    [DbContext(typeof(OficinaDBContexto))]
    [Migration("20230805190050_Relacionamento_orcamento_Servico")]
    partial class Relacionamento_orcamento_Servico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Orcamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CpfResponsavel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataAprovacaoCliente")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFinalOrcamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicialOrcamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusOrcamento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CodChassi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Veiculo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Veiculo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OrcamentoServico", b =>
                {
                    b.Property<Guid>("OrcamentosId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ServicosId")
                        .HasColumnType("char(36)");

                    b.HasKey("OrcamentosId", "ServicosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("OrcamentoServico");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Carro", b =>
                {
                    b.HasBaseType("OficinaWebMVC.Database.Entities.Veiculo");

                    b.Property<int>("ModeloCarro")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Carro");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Moto", b =>
                {
                    b.HasBaseType("OficinaWebMVC.Database.Entities.Veiculo");

                    b.Property<int>("ModeloMoto")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Moto");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Orcamento", b =>
                {
                    b.HasOne("OficinaWebMVC.Database.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficinaWebMVC.Database.Entities.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("OficinaWebMVC.Database.Entities.Veiculo", b =>
                {
                    b.HasOne("OficinaWebMVC.Database.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("OrcamentoServico", b =>
                {
                    b.HasOne("OficinaWebMVC.Database.Entities.Orcamento", null)
                        .WithMany()
                        .HasForeignKey("OrcamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficinaWebMVC.Database.Entities.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
