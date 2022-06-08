using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnyBuyStore.Data.Data
{
    public class ProductWish
    {   [Key]
        public int Id { get; set; }

        [Display(Name = "User")]
        public virtual int UserId { get; set; }
        
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = new Product();

        [ForeignKey("UserId")]
        public virtual User User { get; set; }  = new User();
    }
}
