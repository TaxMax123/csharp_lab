using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreWebApplication1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRatios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ReferentCurrencyId = table.Column<int>(type: "int", nullable: false),
                    Ratio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRatios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRatios_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrencyRatios_Currencies_ReferentCurrencyId",
                        column: x => x.ReferentCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UniversalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderIban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverIban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Urgent = table.Column<bool>(type: "bit", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversalOrders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRatios_CurrencyId",
                table: "CurrencyRatios",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRatios_ReferentCurrencyId",
                table: "CurrencyRatios",
                column: "ReferentCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversalOrders_CurrencyId",
                table: "UniversalOrders",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRatios");

            migrationBuilder.DropTable(
                name: "UniversalOrders");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
