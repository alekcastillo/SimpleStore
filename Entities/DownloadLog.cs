using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.6.3
	// The order has the client & product info
	// We use the BaseEntity's CreatedDate as the download date
	public class DownloadLog : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public Order Order { get; set; }
	}
}
