using SimpleStore.Models;
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
		public User User { get; private set; }
		public Country Country { get; private set; }
		public string PhoneNumber1 { get; private set; }
		public string PhoneNumber2 { get; private set; }
		public string Easypay { get; private set; }
	
}
