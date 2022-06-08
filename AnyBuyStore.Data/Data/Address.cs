using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Address
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("house", TypeName = "varchar(200)")]
        public string House { get; set; } = string.Empty;
        
        [Column("street", TypeName = "varchar(200)")]
        public string Street { get; set; }= string.Empty;
        
        [Column("city", TypeName = "varchar(200)")]
        public string City { get; set; }=string.Empty;
        
        [Column("state", TypeName = "varchar(200)")]
        public string State { get; set; } = string.Empty;
        
        [Column("country", TypeName = "varchar(100)")]
        public string Country { get; set; } = string.Empty;
        
        [Column("zipcode", TypeName = "varchar(30)")]
        public string ZipCode { get; set; } = string.Empty;
        
        [Column("address_type", TypeName = "varchar(50)")]
        public string AddressType { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
