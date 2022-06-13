﻿// <auto-generated />
using System;
using Housing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Housing.Data.Migrations
{
    [DbContext(typeof(HousingContext))]
    partial class HousingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Housing.Data.Entities.AdditionalsBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Internet")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Additionals", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.Billing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Appartments")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.ToTable("Billing", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.ElectricityBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<int>("ConsumptionReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Electricity", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.HeatingBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Heating", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.Rent", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Rent", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.RepairsBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Repairs", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.WaterBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint");

                    b.Property<int>("ColdReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.Property<int>("HotReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("BillingId");

                    b.ToTable("Water", "Bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.AdditionalsBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("Additionals")
                        .HasForeignKey("Housing.Data.Entities.AdditionalsBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.ElectricityBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("ElectricityBill")
                        .HasForeignKey("Housing.Data.Entities.ElectricityBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.HeatingBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("HeatingBill")
                        .HasForeignKey("Housing.Data.Entities.HeatingBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.Rent", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("Rent")
                        .HasForeignKey("Housing.Data.Entities.Rent", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.RepairsBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("RepairsBill")
                        .HasForeignKey("Housing.Data.Entities.RepairsBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.WaterBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("WaterBill")
                        .HasForeignKey("Housing.Data.Entities.WaterBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.Billing", b =>
                {
                    b.Navigation("Additionals")
                        .IsRequired();

                    b.Navigation("ElectricityBill")
                        .IsRequired();

                    b.Navigation("HeatingBill")
                        .IsRequired();

                    b.Navigation("Rent")
                        .IsRequired();

                    b.Navigation("RepairsBill")
                        .IsRequired();

                    b.Navigation("WaterBill")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}