using System;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
	public Employee()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public Person Person { get; private set; }
		public string Email { get; private set; }


	}
}
