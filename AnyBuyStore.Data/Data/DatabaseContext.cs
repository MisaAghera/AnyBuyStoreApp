using AnyBuyStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Data.Data
{
    public class DatabaseContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("AspUser");
         
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Discount> Discount  { get;set;}
        public DbSet<Address> Address { get;set;}
        public DbSet<Order> Order { get;set;}
        public DbSet<ProductCart> ProductCart { get;set;}
        public DbSet<ProductSubcategory> ProductSubcategory { get;set;}
        public DbSet<OrderDetails> OrderDetails { get;set;}
        public DbSet<States> States { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

    }
}
