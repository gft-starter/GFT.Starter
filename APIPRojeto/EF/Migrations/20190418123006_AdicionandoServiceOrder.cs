using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace APIPRojeto.EF.Migrations
{
    public partial class AdicionandoServiceOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_ServiceOrders_CarId",
            //    table: "ServiceOrders",
            //    column: "CarId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ServiceOrders_ServiceId",
            //    table: "ServiceOrders",
            //    column: "ServiceId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceOrders_Cars_CarId",
            //    table: "ServiceOrders",
            //    column: "CarId",
            //    principalTable: "Cars",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceOrders_Services_ServiceId",
            //    table: "ServiceOrders",
            //    column: "ServiceId",
            //    principalTable: "Services",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateTable(
                name: "ServiceOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceOrders_Cars_CarId",
            //    table: "ServiceOrders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceOrders_Services_ServiceId",
            //    table: "ServiceOrders");

            //migrationBuilder.DropIndex(
            //    name: "IX_ServiceOrders_CarId",
            //    table: "ServiceOrders");

            //migrationBuilder.DropIndex(
            //    name: "IX_ServiceOrders_ServiceId",
            //    table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceOrder");
        }
    }
}
