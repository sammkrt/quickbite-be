using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "DeliveryCost", "Description", "Email", "Location", "MainPictureUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 4.0, "Welcome to Amsterdam Cafe, where unique flavors meet!", "info@amsterdamcafe.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/McDonald's2.png", "Amsterdam Cafe", "+31 20 123 4567" },
                    { 2, 5.0, "Discover the rich and exotic flavors of Indonesian cuisine.", "info@indonesiandelight.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/IndonesianDelight.webp", "Indonesian Delight", "+31 20 456 7890" },
                    { 3, 6.0, "Authentic Italian cuisine made with the finest ingredients.", "info@italianos.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Italinos.png", "Italiano's", "+31 20 555 1212" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, "A selection of the best Dutch cheeses.", "Dutch Cheese Platter", 15.0, 1 },
                    { 2, 2, "A delicious ice cream sundae topped with traditional Dutch stroopwafels.", "Stroopwafel Sundae", 8.0, 1 },
                    { 3, 3, "Crispy, savory Dutch meatballs.", "Bitterballen", 6.0, 1 },
                    { 4, 3, "Indonesian fried rice with vegetables and meat.", "Nasi Goreng", 12.0, 2 },
                    { 5, 4, "Tender marinated meat skewers with peanut sauce.", "Satay Skewers", 10.0, 2 },
                    { 6, 5, "A refreshing Indonesian salad with peanut sauce dressing.", "Gado-Gado Salad", 8.0, 2 },
                    { 7, 3, "A classic pizza topped with tomato sauce, mozzarella, and fresh basil.", "Margherita Pizza", 10.0, 3 },
                    { 8, 5, "A creamy pasta dish with pancetta and Parmesan cheese.", "Spaghetti Carbonara", 14.0, 3 },
                    { 9, 1, "A decadent Italian dessert made with ladyfingers, espresso, and mascarpone cheese.", "Tiramisu", 8.0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
