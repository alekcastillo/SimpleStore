using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Movie
/// </summary>
public class Movie
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public Product Product { get; private set; }
		public string Producer { get; private set; }
		public string MinutesLong { get; private set; }
		public string language { get; private set; }
	
}
