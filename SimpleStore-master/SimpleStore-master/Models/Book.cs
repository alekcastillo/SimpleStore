using System;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
	public Book()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public Product Product { get; private set; }
		public string ISBN { get; private set; }
		public string Pages { get; private set; }
	}
}
