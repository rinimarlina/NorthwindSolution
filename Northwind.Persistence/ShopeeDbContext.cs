/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.Domain.Entities;
using System;


namespace Northwind.Persistence
{
    //untuk penghubung table db dengan northwind.domain
    public class ShopeeDbContext : DbContext
    {
        private static IConfigurationRoot configuration;

        public ShopeeDbContext (DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
*/