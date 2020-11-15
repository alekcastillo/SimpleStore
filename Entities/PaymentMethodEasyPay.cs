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
		public Guid Id { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public int AccountId { get; set; }
		public int SecurityNumber { get; set; }
		public string Password { get; set; }
	}
}
