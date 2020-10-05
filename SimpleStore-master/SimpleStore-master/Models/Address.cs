using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class1()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string Country { get; private set; }
		public string State { get; private set; }
		public string City { get; private set; }
		public string PostalCode { get; private set; }
		public string AddressDetail { get; private set; }
				}
}
