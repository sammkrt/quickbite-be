using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Models;

namespace QuickBiteBE.Data;

public class QuickBiteContext : DbContext
{
    public QuickBiteContext(DbContextOptions<QuickBiteContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Cart> Carts { get; set; } = default!;

    public DbSet<CartDish> CartDishes { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    public DbSet<Dish> Dishes { get; set; } = default!;

    public DbSet<Order> Orders { get; set; } = default!;

    public DbSet<Restaurant> Restaurants { get; set; } = default!;

    public DbSet<Role> Roles { get; set; } = default!;
}