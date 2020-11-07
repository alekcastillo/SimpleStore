using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.4.4, 5.4.2
	public class ProductBook : BaseEntity
	{
		[Key]
		public string Code { get; set; }
		public Product Product { get; set; }
		public ProductBookSubject Subject { get; set; }
		public string Author { get; set; }
		public string Publisher { get; set; }
	}
}
