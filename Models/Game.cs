using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Game
    {
        [Key]
        public int Id {get; set;} = 0;

        [Required]
        [Display(Name = "Genre")]
        public int GenreId {get; set;} = 0;

        [Required, StringLength(300)]
        public string Name {get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description {get; set;} = string.Empty;

        [StringLength(250)]
        public string? Image {get; set;} = string.Empty;

        public virtual ICollection<Subscription> Subscriptions {get; set;}

        // relationship
        [ForeignKey("GenreId")]
        public virtual Genre? Genre {get; set;}

    }
}