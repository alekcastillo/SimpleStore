using System;

/// <summary>
/// Summary description for TypeInterpretation
/// </summary>
public class TypeInterpretation
{
	public TypeInterpretation()
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string TypeInterpretationName { get; private set; }

	}
}
