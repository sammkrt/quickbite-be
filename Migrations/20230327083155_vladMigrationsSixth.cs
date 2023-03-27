using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class vladMigrationsSixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CartDishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDishes_OrderId",
                table: "CartDishes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDishes_Orders_OrderId",
                table: "CartDishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDishes_Orders_OrderId",
                table: "CartDishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CartDishes_OrderId",
                table: "CartDishes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartDishes");
        }
    }
}
