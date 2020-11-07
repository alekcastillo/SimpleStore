using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.4.3, 5.4.1
	public class ProductMovie : BaseEntity
	{
		[Key]
		public string Code { get; set; }
		public Product Product { get; set; }
		public ProductMovieGenre Genre { get; set; }
		public List<ProductMovieActor> Actors { get; set; }
	}
}
