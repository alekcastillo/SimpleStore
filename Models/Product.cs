using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string PublicationDate { get; private set; }
		public float Price { get; private set; }
		public string Inventory { get; private set; }
		public string Format { get; private set; }
		public string Producer { get; private set; }
		public string FilePath { get; private set; }
	
}
