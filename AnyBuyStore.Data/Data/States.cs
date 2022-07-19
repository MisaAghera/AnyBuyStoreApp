using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class States
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Countries")]
        [Column("Country_id")]
        public virtual int CountryId { get; set; }

        [Column("name")]
        public string Name { get; set; } = String.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }


        public virtual ICollection<Cities> Cities { get; set; }

        public virtual ICollection<Address> Address { get; set; }

    }
}
