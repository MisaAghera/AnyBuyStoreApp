using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnyBuyStore.Data.Data
{
    public class OrderDetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Column("product_id")]
        public virtual int ProductId { get; set; }


        [Display(Name = "Order")]
        [Column("order_id")]
        public virtual int OrderId { get; set; }

        [Display(Name = "Discount")]
        [Column("discount_id")]
        public virtual int? DiscountId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("status", TypeName = "varchar(50)")]
        public string Status { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order{ get; set; }

        [ForeignKey("DiscountId")]
        public virtual Discount? Discount { get; set; }


    }
}
