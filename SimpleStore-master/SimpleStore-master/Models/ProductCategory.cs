using System;

/// <summary>
/// Summary description for ProductCategory
/// </summary>
public class ProductCategory
{
	public ProductCategory()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string NameCategory { get; private set; }
		public string DetailCategory { get; private set; }

	}
}
