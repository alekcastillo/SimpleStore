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
		public Guid Id { get; private set; }
		public PaymentMethod PaymentMethod { get; private set; }
		public string CardNumber { get; private set; }
		public int ExpirationMonth { get; private set; }
		public int ExpirationYear { get; private set; }
		public int CVV { get; private set; }
		public string CardProvider { get; private set; }
	}
}
