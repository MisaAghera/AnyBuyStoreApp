using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Data.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Discount> Discount  { get;set;}
        public DbSet<Address> Address { get;set;}
        public DbSet<Order> Order { get;set;}
        public DbSet<ProductCart> ProductCart { get;set;}
        public DbSet<ProductSubcategory> ProductSubcategory { get;set;}
        public DbSet<ProductWish> ProductWish { get;set;}
        public DbSet<User> User { get;set;}
        public DbSet<OrderDetails> OrderDetails { get;set;}
        


    }
}
