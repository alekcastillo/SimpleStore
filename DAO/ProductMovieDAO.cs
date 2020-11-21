using SimpleStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.DAO
{
    public class ProductMovieDAO
    {
		public string Title { get; set; }
		public float Price { get; set; }
		public int ReleaseYear { get; set; }
		public string Language { get; set; }
		public string FilePath { get; set; }
		public string PreviewFilePath { get; set; }
		public Guid GenreId { get; set; }
		public List<Guid> ActorIds { get; set; }
	}
}
