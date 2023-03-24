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

        public DbSet<QuickBiteBE.Models.User> Users { get; set; } = default!;
    }
