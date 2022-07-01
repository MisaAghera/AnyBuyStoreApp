using AnyBuyStore.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Display(Name = "User")]
        [Column("user_id")]
        public virtual int UserId { get; set; }

        [Display(Name = "Discount")]
        [Column("discount_id")]
        public virtual int? DiscountId { get; set; }

        [Display(Name = "ProductSubcategory")]
        [Column("product_subcategory_id")]
        public virtual int ProductSubcategoryId { get; set; }

        [Column("name",TypeName = "varchar(100)")]
        public string Name { get; set; } = String.Empty;

       
        [Column("description",TypeName = "varchar(255)")]
        public string? Description { get; set; }


        [Column("price")]
        public decimal Price { get; set; }

       
        [Column("brand",TypeName = "varchar(100)")]
        public string Brand { get; set; } = String.Empty;

       
        [Column("image_url")]
        public string? ImageUrl { get; set; } = String.Empty;
        
       
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [ForeignKey("ProductSubcategoryId")]
        public virtual ProductSubcategory ProductSubcategory { get; set; } 
      
        [ForeignKey("DiscountId")]
        public virtual Discount Discount { get; set; } 

        [ForeignKey("UserId")]
        public virtual User User { get; set; } 



        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductWish> ProductWishes { get; set; } 
        public virtual ICollection<ProductCart> ProductCarts { get; set; }


    }
}
