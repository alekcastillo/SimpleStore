using System;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class Purchase
{
	public Purchase()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string PurchaseDate
		public string PaymentMethod
	}
}
