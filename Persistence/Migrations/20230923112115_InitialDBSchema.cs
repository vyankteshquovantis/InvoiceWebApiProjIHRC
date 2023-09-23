using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerMobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNo);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItemMappings",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemMappings", x => new { x.InvoiceNo, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_InvoiceItemMappings_Invoices_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItemMappings_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItemMappings_ItemCode",
                table: "InvoiceItemMappings",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNo",
                table: "Invoices",
                column: "InvoiceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCode",
                table: "Items",
                column: "ItemCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItemMappings");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
