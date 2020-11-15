using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 5.5
	public class Order : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public Product Product { get; set; }
		public User Buyer { get; private set; }
		public float AmountPayed { get; set; }
		// TODO: how to implement easypay?
		public PaymentMethodCard PaymentMethodCard { get; set; }

	}
}
