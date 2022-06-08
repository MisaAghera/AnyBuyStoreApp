using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnyBuyStore.Data.Data
{
    public class OrderDetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }

        [Column("delivery_address_id")]
        [Display(Name = "Address")]
        public virtual int DeliveryAddressId { get; set; }

        [Column("order_id")]
        [Display(Name = "Order")]
        public virtual int OrderId { get; set; }

        [Column("discount_id")]
        [Display(Name = "Discount")]
        public virtual int DiscountId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("status", TypeName = "varchar(50)")]
        public string Status { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = new Product();

        [ForeignKey("DeliveryAddressId")]
        public virtual Address DeliveryAddress { get; set; } = new Address();

        [ForeignKey("OrderId")]
        public virtual Order Order{ get; set; } = new Order();

        [ForeignKey("DiscountId")]
        public virtual Discount? Discount { get; set; }

    }
}
