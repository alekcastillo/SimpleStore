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
		public Guid Id { get; private set; }
		public Product Product { get; private set; }
		public User Buyer { get; private set; }
		public float AmountPayed { get; private set; }
		// TODO: how to implement easypay?
		public PaymentMethodCard PaymentMethodCard { get; private set; }

	}
}
