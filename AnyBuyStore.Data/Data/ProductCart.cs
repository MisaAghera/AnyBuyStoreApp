using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class ProductCart
    {   [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        [Display(Name = "User")]
        public virtual int UserId { get; set; }

        [Column("product_id")]
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }

        [Column("quantity")]
        public  int Quantity { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("is_available")]
        public bool IsAvailable { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual User User { get; set; } = new User();

        [ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
        public virtual Product Product { get; set; } = new Product();


    }
}
