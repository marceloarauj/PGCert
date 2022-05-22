﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220521183101_AdicionandoAntecipacaoCorrecao1")]
    partial class AdicionandoAntecipacaoCorrecao1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Models.EntityModel.Anticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AntecipatedValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorAntecipado");

                    b.Property<DateTime>("FinishedAnalysisDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataFimAnalise");

                    b.Property<decimal>("RequestedValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorSolicitado");

                    b.Property<DateTime>("SolicitationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataSolicitacao");

                    b.Property<DateTime?>("StartAnalysisDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioAnalise");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Anticipation", (string)null);
                });

            modelBuilder.Entity("api.Models.EntityModel.AnticipationTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnticipationId")
                        .HasColumnType("int")
                        .HasColumnName("AntecipacaoId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TransactionNsu")
                        .HasColumnType("int")
                        .HasColumnName("Nsu");

                    b.HasKey("Id");

                    b.HasIndex("AnticipationId");

                    b.ToTable("AnticipationTransaction", (string)null);
                });

            modelBuilder.Entity("api.Models.EntityModel.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AntecipatedValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorAntecipado");

                    b.Property<decimal>("BruteValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorBruto");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int")
                        .HasColumnName("NumeroParcela");

                    b.Property<string>("NSU")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorLiquido");

                    b.Property<DateTime?>("PassedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataRepasse");

                    b.Property<DateTime>("Receivement")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataRecebimento");

                    b.HasKey("Id");

                    b.HasIndex("NSU");

                    b.ToTable("Installment", (string)null);
                });

            modelBuilder.Entity("api.Models.EntityModel.Transaction", b =>
                {
                    b.Property<string>("NSU")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcquirerConfirmation")
                        .HasColumnType("int")
                        .HasColumnName("ConfirmacaoAdquirinte");

                    b.Property<bool?>("Anticipation")
                        .HasColumnType("bit")
                        .HasColumnName("Antecipado");

                    b.Property<DateTime?>("Approval")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAprovacao");

                    b.Property<decimal>("BruteValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorBruto");

                    b.Property<string>("CreditCardLastNumbers")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UltimosDigitosCartao");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataTransacao");

                    b.Property<DateTime?>("Disapproval")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataReprovacao");

                    b.Property<decimal>("FixedRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TaxaFixa");

                    b.Property<int>("InstallmentsNumber")
                        .HasColumnType("int")
                        .HasColumnName("NumeroParcelas");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorLiquido");

                    b.HasKey("NSU");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("api.Models.EntityModel.AnticipationTransaction", b =>
                {
                    b.HasOne("api.Models.EntityModel.Anticipation", "Anticipation")
                        .WithMany("AnticipationTransactions")
                        .HasForeignKey("AnticipationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anticipation");
                });

            modelBuilder.Entity("api.Models.EntityModel.Installment", b =>
                {
                    b.HasOne("api.Models.EntityModel.Transaction", "Transaction")
                        .WithMany("Installments")
                        .HasForeignKey("NSU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("api.Models.EntityModel.Anticipation", b =>
                {
                    b.Navigation("AnticipationTransactions");
                });

            modelBuilder.Entity("api.Models.EntityModel.Transaction", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}
