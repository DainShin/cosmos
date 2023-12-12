using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace Cosmos.Models
{
    public class Order
    {
        [ForeignKey("UserId")]
		public int Id {get; set;} = 0;

		[Required]
		public string UserId {get; set;} = String.Empty;

		[Required]
		[DataType(DataType.Currency)]
		public decimal Total {get; set;} = 0.00M;

		public bool PaymentReceived {get; set;} = false;

		public IdentityUser? User {get; set;}

		[InverseProperty("Order")]
		public virtual ICollection<OrderItem> OrderItems {get; set;} = new List<OrderItem>();
    }
}