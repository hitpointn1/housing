using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Housing.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bills");

            migrationBuilder.CreateTable(
                name: "Billing",
                schema: "Bills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "Date", nullable: false),
                    Appartments = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Additionals",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    Internet = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additionals", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Additionals_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electricity",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    ConsumptionReadings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electricity", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Electricity_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heating",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heating", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Heating_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Rent_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Repairs_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Water",
                schema: "Bills",
                columns: table => new
                {
                    BillingId = table.Column<long>(type: "bigint", nullable: false),
                    HotReadings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    ColdReadings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    Payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Water_Billing_BillingId",
                        column: x => x.BillingId,
                        principalSchema: "Bills",
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Additionals",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Electricity",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Heating",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Rent",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Repairs",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Water",
                schema: "Bills");

            migrationBuilder.DropTable(
                name: "Billing",
                schema: "Bills");
        }
    }
}
