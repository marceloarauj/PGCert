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
    [Migration("20220520095910_AtualizacaoDaTransactionMappt2")]
    partial class AtualizacaoDaTransactionMappt2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Models.EntityModel.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AntecipatedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BruteValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("NSU")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PassedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Receivement")
                        .HasColumnType("datetime2");

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

                    b.Property<bool>("Anticipation")
                        .HasColumnType("bit")
                        .HasColumnName("Antecipado");

                    b.Property<DateTime?>("Approval")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAprovacao");

                    b.Property<decimal>("BruteValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorBruto");

                    b.Property<string>("CreditCardLastNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UltimosDigitosCartao");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataTransacao");

                    b.Property<DateTime>("Disapproval")
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

            modelBuilder.Entity("api.Models.EntityModel.Installment", b =>
                {
                    b.HasOne("api.Models.EntityModel.Transaction", "Transaction")
                        .WithMany("Installments")
                        .HasForeignKey("NSU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("api.Models.EntityModel.Transaction", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}
