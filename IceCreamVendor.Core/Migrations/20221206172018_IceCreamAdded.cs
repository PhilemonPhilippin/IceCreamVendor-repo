using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IceCreamVendor.Core.Migrations
{
    /// <inheritdoc />
    public partial class IceCreamAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IceCream",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flavour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCream", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IceCream",
                columns: new[] { "Id", "Flavour", "Price" },
                values: new object[,]
                {
                    { 1, "vanilla", 1.50m },
                    { 2, "chocolate", 1.50m },
                    { 3, "stracciatella", 1.75m },
                    { 4, "coffee", 1.25m },
                    { 5, "pistachio", 1.80m },
                    { 6, "banana", 1.25m },
                    { 7, "lemon", 1.25m },
                    { 8, "coconut", 1.99m },
                    { 9, "strawberry", 1.99m }
                });

            migrationBuilder.UpdateData(
                table: "Sell",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 1.50m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCream");

            migrationBuilder.UpdateData(
                table: "Sell",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 1.75m);
        }
    }
}
