using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 6.1
	public class PaymentMethodCard : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public string CardNumber { get; set; }
		public int ExpirationMonth { get; set; }
		public int ExpirationYear { get; set; }
		public int CVV { get; private set; }
		public string CardProvider { get; set; }
	}
}
