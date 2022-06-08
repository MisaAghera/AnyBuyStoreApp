using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("discount_id")]
        [Display(Name = "Discount")]
        public virtual int? DiscountId { get; set; }

        [Column("product_subcategory_id")]
        [Display(Name = "ProductSubcategory")]
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
        public string ImageUrl { get; set; } = String.Empty;
        
       
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductSubcategoryId")]
        public virtual ProductSubcategory ProductSubcategory { get; set; } = new ProductSubcategory();

        
        [ForeignKey("DiscountId")]
        public virtual Discount Discount { get; set; } = new Discount();

    }
}
