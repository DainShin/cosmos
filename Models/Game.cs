using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmos.Models
{
    public class Game
    {
        [Key]
        public int Id {get; set;} = 0;

        [Required]
		[StringLength(300)]
        public string Name {get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description {get; set;} = string.Empty;

		[StringLength(300)]
        public string Image {get; set;} = string.Empty;

		[Required]
		public DateTime ReleaseDate {get; set;} = DateTime.Now;

		[Required]
		public bool Enabled {get; set;} = true;

		public DateTime CreatedAt {get; set;} = DateTime.Now;

		[Required]
		[Display(Name = "Developer")]
		public int DeveloperId {get; set;} = 0;

		[Required]
		[Display(Name = "Publisher")]
		public int PublisherId {get; set;} = 0;

		[ForeignKey("DeveloperId")]
		public virtual Developer? Developer {get; set;}

		[ForeignKey("PublisherId")]
		public virtual Publisher? Publisher {get; set;}

		// public virtual ICollection<Genre>? Genres {get; set;} = new List<Genre>();

		// public virtual ICollection<Mode>? Modes {get; set;} = new List<Mode>();

		// public virtual ICollection<Subscription>? Subscriptions {get; set;} = new List<Subscription>();

    }
}