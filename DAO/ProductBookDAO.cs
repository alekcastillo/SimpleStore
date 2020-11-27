using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.DAO
{
    public class ProductBookDAO
	{
		public Guid SubjectId { get; set; }
		public string Code { get; set; }
		public string Author { get; set; }
		public string Publisher { get; set; }
		public string Title { get; set; }
		public float Price { get; set; }
		public int ReleaseYear { get; set; }
		public string Language { get; set; }
		public string FilePath { get; set; }
		public string PreviewFilePath { get; set; }
	}
}
