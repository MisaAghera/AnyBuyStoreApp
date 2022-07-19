using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Countries
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("name")]
        public string Name { get; set; } = String.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Address> Address { get; set; }

    }
}
