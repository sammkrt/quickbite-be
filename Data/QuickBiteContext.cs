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
            // modelBuilder.Entity<User>()
            //     .HasOne(user => user.Cart)
            //     .WithOne()
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
