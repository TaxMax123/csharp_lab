﻿// <auto-generated />
using System;
using ASP.NETCoreWebApplication1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETCoreWebApplication1.Migrations
{
    [DbContext(typeof(UniversalOrderContext))]
    partial class UniversalOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("WebApplication1.Models.CurrencyRatio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Ratio")
                        .HasColumnType("float");

                    b.Property<int>("ReferentCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ReferentCurrencyId");

                    b.ToTable("CurrencyRatios");
                });

            modelBuilder.Entity("WebApplication1.Models.UniversalOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverCall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverIban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderCall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderIban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Urgent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("UniversalOrders");
                });

            modelBuilder.Entity("WebApplication1.Models.CurrencyRatio", b =>
                {
                    b.HasOne("WebApplication1.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Currency", "ReferentCurrency")
                        .WithMany()
                        .HasForeignKey("ReferentCurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("ReferentCurrency");
                });

            modelBuilder.Entity("WebApplication1.Models.UniversalOrder", b =>
                {
                    b.HasOne("WebApplication1.Models.Currency", "Currency")
                        .WithMany("UniversalOrders")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("WebApplication1.Models.Currency", b =>
                {
                    b.Navigation("UniversalOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
