using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{

	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key]
	public Guid Id { get; private set; }
	public Product Product { get; private set; }
	public string ISBN { get; private set; }
	public string Pages { get; private set; }


	
}
