using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Address
/// </summary>
public class Address
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
