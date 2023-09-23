using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingInitialItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Items (ItemCode, Name, Category, UnitPrice, Discount)\r\nVALUES\r\n    ('000001', 'Item 1', 0, 10.99, 0.50),\r\n    ('000002', 'Item 2', 1, 15.99, 0.25),\r\n    ('000003', 'Item 3', 2, 8.50, 0.10),\r\n    ('000004', 'Item 4', 0, 12.75, 0.15),\r\n    ('000005', 'Item 5', 1, 9.99, 0.20);\r\n\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Items");
        }
    }
}
