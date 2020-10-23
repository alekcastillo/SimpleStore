using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 6.2
	public class PaymentMethodEasyPay : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public PaymentMethod PaymentMethod { get; private set; }
		public int AccountId { get; private set; }
		public int SecurityNumber { get; private set; }
		public string Password { get; private set; }
	}
}
