using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Genre
    {
        [Key]
        public int Id {get; set;} = 0;

        [Required, StringLength(300)]
        public string Name {get; set;} = String.Empty;

        [StringLength(1000)]
        public string? Description {get; set;} = String.Empty;

        public virtual ICollection<Game>? Games {get; set;}
    }
}