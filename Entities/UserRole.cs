using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.3.1
	public class UserRole : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; } 


	}
}
