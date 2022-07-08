using AnyBuyStore.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class RefreshToken
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("user_id")]
        public  int UserId { get; set; }

        
        [Column("refreshtoken")]
        public  string? Refreshtoken { get; set; }

    }
}
