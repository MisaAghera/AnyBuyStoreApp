using AnyBuyStore.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Address
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "User")]
        [Column("user_id")]
        public virtual int? UserId { get; set; }

        [Display(Name = "Cities")]
        [Column("city_id")]
        public virtual int? CityId { get; set; }


        [Display(Name = "States")]
        [Column("state_id")]
        public virtual int? StateId { get; set; }


        [Display(Name = "Countries")]
        [Column("country_id")]
        public virtual int? CountryId { get; set; }


        [Column("house", TypeName = "varchar(200)")]
        public string House { get; set; } = string.Empty;
        

        [Column("street", TypeName = "varchar(200)")]
        public string Street { get; set; }= string.Empty;
        
        
        [Column("zipcode", TypeName = "varchar(30)")]
        public string ZipCode { get; set; } = string.Empty;

        
        [Column("address_type", TypeName = "varchar(50)")]
        public string AddressType { get; set; } = string.Empty;


        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;




       
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        [ForeignKey("StateId")]
        public virtual States? States { get; set; }
        [ForeignKey("CityId")]
        public virtual Cities? Cities { get; set; }
        [ForeignKey("CountryId")]
        public virtual Countries? Countries { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
