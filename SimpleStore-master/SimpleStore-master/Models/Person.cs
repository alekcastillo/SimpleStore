using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class Person
{
	public Person()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string LastName { get; private set; }
		public string BirthDate { get; private set; }
		public string Nationality { get; private set; }
		public string RegistryDate { get; private set; }
		public string SecondName { get; private set; }


	}
}
