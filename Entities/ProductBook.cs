using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.4.4, 5.4.2
	public class ProductBook : BaseEntity
	{
		[Key]
		public string Code { get; private set; }
		public Product Product { get; private set; }
		public ProductBookSubject Subject { get; private set; }
		public string Author { get; private set; }
		public string Publisher { get; private set; }
	}
}
