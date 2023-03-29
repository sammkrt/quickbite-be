using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Amsterdam_Cafe.png");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "DeliveryCost", "Description", "Email", "Location", "MainPictureUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 4, 3.5, "Juicy burgers made with fresh ingredients.", "info@burgerjoint.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burgerJoint.png", "Burger Joint", "+31 20 789 1234" },
                    { 5, 7.0, "Experience the flavors of Spain with our authentic cuisine.", "info@lacocinaespanola.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/LaCocina.png", "La Cocina Española", "+31 20 987 6543" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 10, 6, "A juicy beef patty topped with cheese, lettuce, and tomato.", "Classic Burger", 9.0, 4 },
                    { 11, 6, "A vegetarian patty made with fresh vegetables and herbs.", "Veggie Burger", 8.0, 4 },
                    { 12, 7, "A traditional Spanish omelette made with potatoes and onions.", "Spanish Tortilla", 10.0, 5 },
                    { 13, 7, "A classic Spanish rice dish with seafood and saffron.", "Paella Valenciana", 18.0, 5 },
                    { 14, 5, "A refreshing chilled soup made with tomatoes and peppers.", "Gazpacho", 7.0, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainPictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/McDonald's2.png");
        }
    }
}
