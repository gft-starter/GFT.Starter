using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPRojeto.Migrations
{
    public partial class AdicionaServiceOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_CarId",
                table: "ServiceOrders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ServiceId",
                table: "ServiceOrders",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceOrders");
        }
    }
}
