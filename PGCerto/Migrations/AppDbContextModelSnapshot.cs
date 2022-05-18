﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Models.EntityModel.Transaction", b =>
                {
                    b.Property<string>("NSU")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Anticipation")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Approval")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("BruteValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreditCardLastNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Disapproval")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FixedRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NSU");

                    b.ToTable("Transaction", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
