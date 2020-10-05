using System;

/// <summary>
/// Summary description for Rol
/// </summary>
public class Rol
{
	public Rol()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string RolName { get; private set; }
		public string RolDescription { get; private set; }


	}
}
