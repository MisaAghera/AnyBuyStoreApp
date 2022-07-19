using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class Cities
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "States")]
        [Column("State_id")]
        public virtual int StateId { get; set; }

        [Column("name")]
        public string Name { get; set; } = String.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



        [ForeignKey("StateId")]
        public virtual States States { get; set; }

    }
}
