using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Mode
    {
        [Key]
		[Display(Name = "ID")]
        public int Id {get; set;} = 0;

        [Required]
		[StringLength(300)]
        public string Name {get; set;} = String.Empty;

		public DateTime CreatedAt {get; set;} = DateTime.Now;

		public virtual ICollection<Game> Games {get; set;} = new List<Game>();
    }
}