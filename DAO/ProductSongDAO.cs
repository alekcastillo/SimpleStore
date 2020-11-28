using SimpleStore.Entities;
using SimpleStore.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.DAO
{
    public class ProductSongDAO
    {

		public string Code { get; set; }
		public string Title { get; set; }
		public float Price { get; set; }
		public int ReleaseYear { get; set; }
		public string Language { get; set; }
		public string FilePath { get; set; }
		public string PreviewFilePath { get; set; }

		public int InterpretationType { get; set; }
		public Guid GenreId { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public string Country { get; set; }
		public string Label { get; set; }

	}
}
