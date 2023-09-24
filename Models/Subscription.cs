using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Subscription
    {
        [Key]
        public int Id {get; set;} = 0;

        [Required]
        [Display(Name = "Game")]
        public int GameId {get; set;} = 0;

        [Required, StringLength(300)]
        public string Name {get; set;} = String.Empty; // Subscription name

        [Required]
        [Range(0.01, 999999.99)]
        [DataType(DataType.Currency)]
        public decimal Price {get; set;} = 0.01M;
        
        [StringLength(1000)]
        public string? Description {get; set;} = String.Empty;

        [ForeignKey("GameId")]
        public virtual Game? Game {get; set;}

    }
}