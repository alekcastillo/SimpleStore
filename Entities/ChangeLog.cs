using SimpleStore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SimpleStore.Entities
{
	// Requirement 4.6.3
	// The order has the client & product info
	// We use the BaseEntity's CreatedDate as the download date
	public class ChangeLog : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public string Log { get; set; }
		public string Table { get; set; }

		public static void AddCreatedLog(SimpleStoreDbContext context, string table, object modifiedObject)
		{
			var changeLog = new ChangeLog();
			var objectJson = JsonSerializer.Serialize(modifiedObject);
			changeLog.Log = $"Registro añadido: {objectJson}";
			changeLog.Table = table;
			context.ChangeLogs.Add(changeLog);
		}

		public static void AddUpdatedLog(SimpleStoreDbContext context, string table, object modifiedObject)
		{
			var changeLog = new ChangeLog();
			var objectJson = JsonSerializer.Serialize(modifiedObject);
			changeLog.Log = $"Registro actualizado: {objectJson}";
			changeLog.Table = table;
			context.ChangeLogs.Add(changeLog);
		}

		public static void AddDeletedLog(SimpleStoreDbContext context, string table, object modifiedObject)
		{
			var changeLog = new ChangeLog();
			var objectJson = JsonSerializer.Serialize(modifiedObject);
			changeLog.Log = $"Registro eliminado: {objectJson}";
			changeLog.Table = table;
			context.ChangeLogs.Add(changeLog);
		}
	}
}
