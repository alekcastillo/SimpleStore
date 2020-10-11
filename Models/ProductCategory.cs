using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for ProductCategory
/// </summary>
public class ProductCategory
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string NameCategory { get; private set; }
		public string DetailCategory { get; private set; }

	
}
