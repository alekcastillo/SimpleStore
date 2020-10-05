using System;

/// <summary>
/// Summary description for CreditCard
/// </summary>
public class CreditCard
{
	public CreditCard()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string CardNumber { get; private set; }
		public string CVV { get; private set; }
		public string ExpirationDate { get; private set; }
		public string CardName { get; private set; }

	}
}
