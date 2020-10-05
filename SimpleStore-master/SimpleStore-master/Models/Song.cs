using System;

/// <summary>
/// Summary description for Song
/// </summary>
public class Song
{
	public Song()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public Product Product { get; private set; }
		public string MinutesLong { get; private set; }
	}
}
