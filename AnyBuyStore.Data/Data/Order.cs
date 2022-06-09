using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnyBuyStore.Data.Data
{
    public class Order
    {   
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Display(Name = "User")]
        [Column("user_id")]
        public virtual int UserId { get; set; }
        
        [Column("total_amount")]
        public decimal TotalAmount { get; set; }
        
        [Column("total_discount")]
        public decimal? TotalDiscount { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


       
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public virtual ICollection<OrderDetails> OrderDetails { get; set; }


    }
}
