using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class deletedDishFromCartDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDishes_Dishes_DishId",
                table: "CartDishes");

            migrationBuilder.DropIndex(
                name: "IX_CartDishes_DishId",
                table: "CartDishes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartDishes_DishId",
                table: "CartDishes",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDishes_Dishes_DishId",
                table: "CartDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
