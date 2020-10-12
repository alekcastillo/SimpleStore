using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class PurchaseLog
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string PurchaseDate { get; private set; }
		public PaymentMethodCard PaymentMethodCard { get; private set; }

}
