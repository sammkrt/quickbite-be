using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class hopefullyLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryCost = table.Column<double>(type: "float", nullable: false),
                    MainPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDish = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDishes_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDishes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "DeliveryCost", "Description", "Email", "Location", "MainPictureUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 4.0, "Welcome to Amsterdam Cafe, where unique flavors meet!", "info@amsterdamcafe.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Amsterdam_Cafe.png", "Amsterdam Cafe", "+31 20 123 4567" },
                    { 2, 5.0, "Discover the rich and exotic flavors of Indonesian cuisine.", "info@indonesiandelight.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/IndonesianDelight.webp", "Indonesian Delight", "+31 20 456 7890" },
                    { 3, 6.0, "Authentic Italian cuisine made with the finest ingredients.", "info@italianos.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Italinos.png", "Italiano's", "+31 20 555 1212" },
                    { 4, 3.5, "Juicy burgers made with fresh ingredients.", "info@burgerjoint.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burgerJoint.png", "Burger Joint", "+31 20 789 1234" },
                    { 5, 7.0, "Experience the flavors of Spain with our authentic cuisine.", "info@lacocinaespanola.com", "Amsterdam, Netherlands", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/LaCocina.png", "La Cocina Española", "+31 20 987 6543" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PictureUrl", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, "A selection of the best Dutch cheeses.", "Dutch Cheese Platter", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/DutchCheesePlate.jpeg", 15.0, 1 },
                    { 2, 2, "A delicious ice cream sundae topped with traditional Dutch stroopwafels.", "Stroopwafel Sundae", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/StroopWaffelSundae.jpeg", 8.0, 1 },
                    { 3, 3, "Crispy, savory Dutch meatballs.", "Bitterballen", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Bitterballen.jpeg", 6.0, 1 },
                    { 4, 3, "Indonesian fried rice with vegetables and meat.", "Nasi Goreng", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/nasiGoren.jpeg", 12.0, 2 },
                    { 5, 4, "Tender marinated meat skewers with peanut sauce.", "Satay Skewers", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SataySkewer.jpeg", 10.0, 2 },
                    { 6, 5, "A refreshing Indonesian salad with peanut sauce dressing.", "Gado-Gado Salad", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/gadoGadoSalad.jpeg", 8.0, 2 },
                    { 7, 3, "A classic pizza topped with tomato sauce, mozzarella, and fresh basil.", "Margherita Pizza", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/MargaritaPizza.jpeg", 10.0, 3 },
                    { 8, 5, "A creamy pasta dish with pancetta and Parmesan cheese.", "Spaghetti Carbonara", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpagettiCarbonora.jpeg", 14.0, 3 },
                    { 9, 1, "A decadent Italian dessert made with ladyfingers, espresso, and mascarpone cheese.", "Tiramisu", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Tiramisu.jpeg", 8.0, 3 },
                    { 10, 6, "A juicy beef patty topped with cheese, lettuce, and tomato.", "Classic Burger", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/ClassicBurger.jpeg", 9.0, 4 },
                    { 11, 6, "A vegetarian patty made with fresh vegetables and herbs.", "Veggie Burger", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/VeggieBurger.jpeg", 8.0, 4 },
                    { 12, 7, "A traditional Spanish omelette made with potatoes and onions.", "Spanish Tortilla", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpanisTortilla.jpeg", 10.0, 5 },
                    { 13, 7, "A classic Spanish rice dish with seafood and saffron.", "Paella Valenciana", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/PaellaValencia.jpeg", 18.0, 5 },
                    { 14, 5, "A refreshing chilled soup made with tomatoes and peppers.", "Gazpacho", "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Gazpacho.jpeg", 7.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDishes_CartId",
                table: "CartDishes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDishes_DishId",
                table: "CartDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDishes_OrderId",
                table: "CartDishes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDishes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
