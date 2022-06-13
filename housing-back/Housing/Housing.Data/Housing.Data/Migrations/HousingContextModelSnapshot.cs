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
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<decimal>("Internet")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("internet");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_additionals");

                    b.ToTable("additionals", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.Billing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Appartments")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)")
                        .HasColumnName("appartments");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("Date")
                        .HasColumnName("date");

                    b.HasKey("Id")
                        .HasName("pk_billing");

                    b.ToTable("billing", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.ElectricityBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<int>("ConsumptionReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("consumption_readings");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_electricity");

                    b.ToTable("electricity", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.HeatingBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_heating");

                    b.ToTable("heating", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.Rent", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_rent");

                    b.ToTable("rent", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.RepairsBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_repairs");

                    b.ToTable("repairs", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.WaterBill", b =>
                {
                    b.Property<long>("BillingId")
                        .HasColumnType("bigint")
                        .HasColumnName("billing_id");

                    b.Property<int>("ColdReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("cold_readings");

                    b.Property<int>("HotReadings")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("hot_readings");

                    b.Property<decimal>("Payment")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("payment");

                    b.HasKey("BillingId")
                        .HasName("pk_water");

                    b.ToTable("water", "bills");
                });

            modelBuilder.Entity("Housing.Data.Entities.AdditionalsBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("Additionals")
                        .HasForeignKey("Housing.Data.Entities.AdditionalsBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_additionals_billings_billing_id");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.ElectricityBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("ElectricityBill")
                        .HasForeignKey("Housing.Data.Entities.ElectricityBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_electricity_billing_billing_id");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.HeatingBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("HeatingBill")
                        .HasForeignKey("Housing.Data.Entities.HeatingBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_heating_billing_billing_id");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.Rent", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("Rent")
                        .HasForeignKey("Housing.Data.Entities.Rent", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rent_billing_billing_id");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.RepairsBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("RepairsBill")
                        .HasForeignKey("Housing.Data.Entities.RepairsBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_repairs_billing_billing_id");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("Housing.Data.Entities.WaterBill", b =>
                {
                    b.HasOne("Housing.Data.Entities.Billing", "Billing")
                        .WithOne("WaterBill")
                        .HasForeignKey("Housing.Data.Entities.WaterBill", "BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_water_billing_billing_id");

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
