using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Discount
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }

        [Column("type",TypeName = "varchar(100)")]
        public int Type { get; set; }

        [Column("value",TypeName = "varchar(100)")]
        public float Value { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column("Is_active", TypeName = "BIT")]
        public bool IsActive { get; set; }


        
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual OrderDetails OrderDetails { get; set; } = new OrderDetails();
    }


}
