using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class Purchase
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string PurchaseDate { get; private set; }
		public string PaymentMethod { get; private set; }

}
