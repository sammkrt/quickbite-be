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
        public DbSet<Picture> Pictures { get; set; } = default!;

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
                        MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/McDonald's2.png",
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
                    }
                );

                modelBuilder.Entity<Dish>().HasData(
                    new Dish
                    {
                        Id = 1, Name = "Dutch Cheese Platter", Description = "A selection of the best Dutch cheeses.",
                        Price = 15.0, RestaurantId = 1,CategoryId = 1
                    },
                    new Dish
                    {
                        Id = 2, Name = "Stroopwafel Sundae",
                        Description = "A delicious ice cream sundae topped with traditional Dutch stroopwafels.",
                        Price = 8.0,
                        RestaurantId = 1,CategoryId = 2
                    },
                    new Dish
                    {
                        Id = 3, Name = "Bitterballen", Description = "Crispy, savory Dutch meatballs.", Price = 6.0,
                        RestaurantId = 1,CategoryId = 3
                    },
                    new Dish
                    {
                        Id = 4, Name = "Nasi Goreng", Description = "Indonesian fried rice with vegetables and meat.",
                        Price = 12.0, RestaurantId = 2,CategoryId = 3
                    },
                    new Dish
                    {
                        Id = 5, Name = "Satay Skewers",
                        Description = "Tender marinated meat skewers with peanut sauce.",
                        Price = 10.0, RestaurantId = 2,CategoryId = 4
                    },
                    new Dish
                    {
                        Id = 6, Name = "Gado-Gado Salad",
                        Description = "A refreshing Indonesian salad with peanut sauce dressing.", Price = 8,
                        RestaurantId = 2,CategoryId = 5
                    },
                    new Dish
                    {
                        Id = 7, Name = "Margherita Pizza",
                        Description = "A classic pizza topped with tomato sauce, mozzarella, and fresh basil.",
                        Price = 10.0,
                        RestaurantId = 3,CategoryId = 3
                    },
                    new Dish
                    {
                        Id = 8, Name = "Spaghetti Carbonara",
                        Description = "A creamy pasta dish with pancetta and Parmesan cheese.", Price = 14.0,
                        RestaurantId = 3,CategoryId = 5
                    },
                    new Dish
                    {
                        Id = 9, Name = "Tiramisu",
                        Description =
                            "A decadent Italian dessert made with ladyfingers, espresso, and mascarpone cheese.",
                        Price = 8.0, RestaurantId = 3,CategoryId = 1
                    }
                );
            }
        }
    }
