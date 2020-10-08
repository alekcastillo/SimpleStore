using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for TypeInterpretation
/// </summary>
public class TypeInterpretation
{
	
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; private set; }
		public string TypeInterpretationName { get; private set; }

	
}
