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
		public string Code { get; private set; }
		public Product Product { get; private set; }
		public ProductSongGenre Genre { get; private set; }
		public string Artist { get; private set; }
		public string Album { get; private set; }
		public SongInterpretationType InterpretationType { get; private set; }
		public string Country { get; private set; }
		public string Label { get; private set; }
	}
}
