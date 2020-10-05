using System;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
	public Product()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string PublicationDate { get; private set; }
		public string Prize { get; private set; }
		public string Inventory { get; private set; }
		public string Format { get; private set; }
		public string Producer { get; private set; }
		public string Archive { get; private set; }
	}
}
