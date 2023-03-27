﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QuickBiteBE.Migrations
{
    [DbContext(typeof(QuickBiteContext))]
    partial class QuickBiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuickBiteBE.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("QuickBiteBE.Models.CartDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartDishes");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A selection of the best Dutch cheeses.",
                            Name = "Dutch Cheese Platter",
                            Price = 15.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "A delicious ice cream sundae topped with traditional Dutch stroopwafels.",
                            Name = "Stroopwafel Sundae",
                            Price = 8.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Crispy, savory Dutch meatballs.",
                            Name = "Bitterballen",
                            Price = 6.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "Indonesian fried rice with vegetables and meat.",
                            Name = "Nasi Goreng",
                            Price = 12.0,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Description = "Tender marinated meat skewers with peanut sauce.",
                            Name = "Satay Skewers",
                            Price = 10.0,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            Description = "A refreshing Indonesian salad with peanut sauce dressing.",
                            Name = "Gado-Gado Salad",
                            Price = 8.0,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "A classic pizza topped with tomato sauce, mozzarella, and fresh basil.",
                            Name = "Margherita Pizza",
                            Price = 10.0,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Description = "A creamy pasta dish with pancetta and Parmesan cheese.",
                            Name = "Spaghetti Carbonara",
                            Price = 14.0,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "A decadent Italian dessert made with ladyfingers, espresso, and mascarpone cheese.",
                            Name = "Tiramisu",
                            Price = 8.0,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("QuickBiteBE.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DeliveryCost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainPictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeliveryCost = 4.0,
                            Description = "Welcome to Amsterdam Cafe, where unique flavors meet!",
                            Email = "info@amsterdamcafe.com",
                            Location = "Amsterdam, Netherlands",
                            MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/McDonald's2.png",
                            Name = "Amsterdam Cafe",
                            PhoneNumber = "+31 20 123 4567"
                        },
                        new
                        {
                            Id = 2,
                            DeliveryCost = 5.0,
                            Description = "Discover the rich and exotic flavors of Indonesian cuisine.",
                            Email = "info@indonesiandelight.com",
                            Location = "Amsterdam, Netherlands",
                            MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/IndonesianDelight.webp",
                            Name = "Indonesian Delight",
                            PhoneNumber = "+31 20 456 7890"
                        },
                        new
                        {
                            Id = 3,
                            DeliveryCost = 6.0,
                            Description = "Authentic Italian cuisine made with the finest ingredients.",
                            Email = "info@italianos.com",
                            Location = "Amsterdam, Netherlands",
                            MainPictureUrl = "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Italinos.png",
                            Name = "Italiano's",
                            PhoneNumber = "+31 20 555 1212"
                        });
                });

            modelBuilder.Entity("QuickBiteBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuickBiteBE.Models.CartDish", b =>
                {
                    b.HasOne("QuickBiteBE.Models.Cart", null)
                        .WithMany("CartDishes")
                        .HasForeignKey("CartId");

                    b.HasOne("QuickBiteBE.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBiteBE.Models.Order", null)
                        .WithMany("Dishes")
                        .HasForeignKey("OrderId");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Dish", b =>
                {
                    b.HasOne("QuickBiteBE.Models.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Order", b =>
                {
                    b.HasOne("QuickBiteBE.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("QuickBiteBE.Models.User", b =>
                {
                    b.HasOne("QuickBiteBE.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Cart", b =>
                {
                    b.Navigation("CartDishes");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Order", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("QuickBiteBE.Models.Restaurant", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("QuickBiteBE.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
