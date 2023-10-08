using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Subscription
    {
        [Key]
        public int Id {get; set;} = 0;

        [Required]
		[StringLength(300)]
        public string Name {get; set;} = String.Empty;

        [Required]
        [Range(0.00, 999999.99)]
        [DataType(DataType.Currency)]
        public decimal Price {get; set;} = 0.01M;
        
		public DateTime CreatedAt {get; set;} = DateTime.Now;

		public virtual ICollection<Game> Games {get; set;} = new List<Game>();
    }
}