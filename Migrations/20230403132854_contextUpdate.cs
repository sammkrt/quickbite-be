using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class contextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/amterdam-cafe-dutch-cheese-platter.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/amterdam-cafe-stroopwafel-sundae.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/amterdam-cafe-bitterballen.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/indonesian-delight-nasi-goren.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/indonesian-delight-satay-skewers.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/indonesian-delight-gado-gado-salad.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/italianos-margherita-pizza.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/italianos-spaghetti-carbonara.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/italianos-tiramisu.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burger-joint-classic-burger.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burger-joint-veggie-burger.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/la-cocina-espanola-spanish-tortilla.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/la-cocina-espanola-paella-valenciana.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/la-cocina-espanola-gazpacho.jpg");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PictureUrl", "Price", "RestaurantId" },
                values: new object[] { 15, 3, "A moist cake made with fresh bananas and a hint of cinnamon.", "Banana Cake", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burger-joint-banana-cacke.jpg", 5.9900000000000002, 4 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/amsterdam-cafe.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/indonesian-delight.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/italianos.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burger-joint.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/la-cocina-espanola.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/DutchCheesePlate.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/StroopWaffelSundae.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Bitterballen.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/nasiGoren.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SataySkewer.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/gadoGadoSalad.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/MargaritaPizza.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpagettiCarbonora.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Tiramisu.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/ClassicBurger.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/VeggieBurger.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpanisTortilla.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/PaellaValencia.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Gazpacho.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Amsterdam_Cafe.png");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/IndonesianDelight.webp");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Italinos.png");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burgerJoint.png");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/LaCocina.png");
        }
    }
}
