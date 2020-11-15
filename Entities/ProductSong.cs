using SimpleStore.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Entities
{
	// Requirement 4.4.5, 5.4.3
	public class ProductSong
	{
		[Key]
		public string Code { get; set; }
		public Product Product { get; set; }
		public ProductSongGenre Genre { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public SongInterpretationType InterpretationType { get; set; }
		public string Country { get; set; }
		public string Label { get; set; }
	}
}
