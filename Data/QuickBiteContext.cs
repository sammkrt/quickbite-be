using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;

    public class QuickBiteContext : DbContext
    {
        public QuickBiteContext (DbContextOptions<QuickBiteContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Dish> Dishes { get; set; } = default!;
        public DbSet<CartDish> CartDishes { get; set; } = default!;
        public DbSet<Restaurant> Restaurants { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            ModelBuilderExtensions.Seed(modelBuilder);
        }

        public static class ModelBuilderExtensions
        {
            public static void Seed( ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Restaurant>().HasData(
                    new Restaurant
                    {
                        Id = 1,
                        Name = "Amsterdam Cafe",
                        Description = "Welcome to Amsterdam Cafe, where unique flavors meet!",
                        Location = "Amsterdam, Netherlands",
                        PhoneNumber = "+31 20 123 4567",
                        Email = "info@amsterdamcafe.com",
                        DeliveryCost = 4.0,
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Amsterdam_Cafe.png",
                    },
                    new Restaurant
                    {
                        Id = 2,
                        Name = "Indonesian Delight",
                        Description = "Discover the rich and exotic flavors of Indonesian cuisine.",
                        Location = "Amsterdam, Netherlands",
                        PhoneNumber = "+31 20 456 7890",
                        Email = "info@indonesiandelight.com",
                        DeliveryCost = 5.0,
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/IndonesianDelight.webp",
                    },
                    new Restaurant
                    {
                        Id = 3,
                        Name = "Italiano's",
                        Description = "Authentic Italian cuisine made with the finest ingredients.",
                        Location = "Amsterdam, Netherlands",
                        PhoneNumber = "+31 20 555 1212",
                        Email = "info@italianos.com",
                        DeliveryCost = 6.0,
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Italinos.png",
                    },
                    new Restaurant
                    {
                        Id = 4,
                        Name = "Burger Joint",
                        Description = "Juicy burgers made with fresh ingredients.",
                        Location = "Amsterdam, Netherlands",
                        PhoneNumber = "+31 20 789 1234",
                        Email = "info@burgerjoint.com",
                        DeliveryCost = 3.5,
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/burgerJoint.png",
                    },
                    new Restaurant
                    {
                        Id = 5,
                        Name = "La Cocina Española",
                        Description = "Experience the flavors of Spain with our authentic cuisine.",
                        Location = "Amsterdam, Netherlands",
                        PhoneNumber = "+31 20 987 6543",
                        Email = "info@lacocinaespanola.com",
                        DeliveryCost = 7.0,
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/LaCocina.png",
                    }
                    
                );
                
                modelBuilder.Entity<Dish>().HasData(
                    new Dish
                    {
                        Id = 1, Name = "Dutch Cheese Platter", Description = "A selection of the best Dutch cheeses.",
                        Price = 15.0, RestaurantId = 1,CategoryId = 1,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/DutchCheesePlate.jpeg"
                    },
                    new Dish
                    {
                        Id = 2, Name = "Stroopwafel Sundae",
                        Description = "A delicious ice cream sundae topped with traditional Dutch stroopwafels.",
                        Price = 8.0,
                        RestaurantId = 1,CategoryId = 2,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/StroopWaffelSundae.jpeg"
                    },
                    new Dish
                    {
                        Id = 3, Name = "Bitterballen", Description = "Crispy, savory Dutch meatballs.", Price = 6.0,
                        RestaurantId = 1,CategoryId = 3,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Bitterballen.jpeg"
                    },
                    new Dish
                    {
                        Id = 4, Name = "Nasi Goreng", Description = "Indonesian fried rice with vegetables and meat.",
                        Price = 12.0, RestaurantId = 2,CategoryId = 3,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/nasiGoren.jpeg"
                    },
                    new Dish
                    {
                        Id = 5, Name = "Satay Skewers",
                        Description = "Tender marinated meat skewers with peanut sauce.",
                        Price = 10.0, RestaurantId = 2,CategoryId = 4,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SataySkewer.jpeg"
                    },
                    new Dish
                    {
                        Id = 6, Name = "Gado-Gado Salad",
                        Description = "A refreshing Indonesian salad with peanut sauce dressing.", Price = 8,
                        RestaurantId = 2,CategoryId = 5,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/gadoGadoSalad.jpeg"
                    },
                    new Dish
                    {
                        Id = 7, Name = "Margherita Pizza",
                        Description = "A classic pizza topped with tomato sauce, mozzarella, and fresh basil.",
                        Price = 10.0,
                        RestaurantId = 3,CategoryId = 3,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/MargaritaPizza.jpeg"
                    },
                    new Dish
                    {
                        Id = 8, Name = "Spaghetti Carbonara",
                        Description = "A creamy pasta dish with pancetta and Parmesan cheese.", Price = 14.0,
                        RestaurantId = 3,CategoryId = 5,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpagettiCarbonora.jpeg"
                    },
                    new Dish
                    {
                        Id = 9, Name = "Tiramisu",
                        Description =
                            "A decadent Italian dessert made with ladyfingers, espresso, and mascarpone cheese.",
                        Price = 8.0, RestaurantId = 3,CategoryId = 1,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Tiramisu.jpeg"
                    },
                    new Dish
                    {
                        Id = 10,
                        Name = "Classic Burger",
                        Description = "A juicy beef patty topped with cheese, lettuce, and tomato.",
                        Price = 9.0,
                        RestaurantId = 4,
                        CategoryId = 6,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/ClassicBurger.jpeg"
                    },
                    new Dish
                    {
                        Id = 11,
                        Name = "Veggie Burger",
                        Description = "A vegetarian patty made with fresh vegetables and herbs.",
                        Price = 8.0,
                        RestaurantId = 4,
                        CategoryId = 6,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/VeggieBurger.jpeg"
                    },
                    new Dish
                    {
                        Id = 12,
                        Name = "Spanish Tortilla",
                        Description = "A traditional Spanish omelette made with potatoes and onions.",
                        Price = 10.0,
                        RestaurantId = 5,
                        CategoryId = 7,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpanisTortilla.jpeg"
                    },
                    new Dish
                    {
                        Id = 13,
                        Name = "Paella Valenciana",
                        Description = "A classic Spanish rice dish with seafood and saffron.",
                        Price = 18.0,
                        RestaurantId = 5,
                        CategoryId = 7,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/PaellaValencia.jpeg"
                    },
                    new Dish
                    {
                        Id = 14,
                        Name = "Gazpacho",
                        Description = "A refreshing chilled soup made with tomatoes and peppers.",
                        Price = 7.0,
                        RestaurantId = 5,
                        CategoryId = 5,PictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Gazpacho.jpeg"
                    }
                );
            }
        }
    }