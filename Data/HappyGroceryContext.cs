using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HappyGrocery.Models;

namespace HappyGrocery.Data
{
    public class HappyGroceryContext : DbContext
    {
        public HappyGroceryContext (DbContextOptions<HappyGroceryContext> options)
            : base(options)
        {
        }

        public DbSet<HappyGrocery.Models.Product> Product { get; set; } = default!;

        public DbSet<HappyGrocery.Models.Category> Category { get; set; } = default!;

        public DbSet<HappyGrocery.Models.User> User { get; set; } = default!;

        public DbSet<HappyGrocery.Models.ShoppingCartItem> ShoppingCartItem { get; set; } = default!;

       
    }
}
