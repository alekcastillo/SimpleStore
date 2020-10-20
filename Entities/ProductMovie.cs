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
		public string Code { get; private set; }
		public Product Product { get; private set; }
		public ProductMovieGenre Genre { get; private set; }
		public List<ProductMovieActor> Actors { get; private set; }
	}
}
