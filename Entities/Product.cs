using SimpleStore.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.4.3, 4.4.4, 4.4.5, 5.4.1, 5.4.2, 5.4.3
	// Extended by the other 3 specific product tables
	public class Product : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string Title { get; private set; }
		public float Price { get; private set; }
		public int ReleaseYear { get; private set; }
		public string Language { get; private set; }
		public ProductType Type { get; private set; }
		public string FilePath { get; private set; }
		public string PreviewFilePath { get; private set; }

	}
}
