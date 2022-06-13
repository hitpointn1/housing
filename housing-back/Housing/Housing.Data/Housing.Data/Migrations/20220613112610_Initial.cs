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
                name: "bills");

            migrationBuilder.CreateTable(
                name: "billing",
                schema: "bills",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "Date", nullable: false),
                    appartments = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_billing", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "additionals",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    internet = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_additionals", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_additionals_billings_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "electricity",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    consumption_readings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_electricity", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_electricity_billing_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "heating",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_heating", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_heating_billing_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rent",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rent", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_rent_billing_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repairs",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repairs", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_repairs_billing_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water",
                schema: "bills",
                columns: table => new
                {
                    billing_id = table.Column<long>(type: "bigint", nullable: false),
                    hot_readings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    cold_readings = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_water", x => x.billing_id);
                    table.ForeignKey(
                        name: "fk_water_billing_billing_id",
                        column: x => x.billing_id,
                        principalSchema: "bills",
                        principalTable: "billing",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additionals",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "electricity",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "heating",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "rent",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "repairs",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "water",
                schema: "bills");

            migrationBuilder.DropTable(
                name: "billing",
                schema: "bills");
        }
    }
}
