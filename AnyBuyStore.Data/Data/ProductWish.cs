using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnyBuyStore.Data.Data
{
    public class ProductWish
    {   [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "User")]
        [Column("user_id")]
        public virtual int UserId { get; set; }

        [Display(Name = "Product")]
        [Column("product_id")]
        public virtual int ProductId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
