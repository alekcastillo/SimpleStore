using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public Person Person { get; private set; }
		public string PhoneNumber1 { get; private set; }
		public string PhoneNumber2 { get; private set; }
		public string Email { get; private set; }
		public string Easypay { get; private set; }
		public string NombreUsuario { get; private set; }
		public string Password { get; private set; }
	
}
