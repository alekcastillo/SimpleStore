using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Requirement 4.4.1
    public class TableConsecutive : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }
        public string Table { get; private set; }
        public int Current { get; private set; }
        public bool UsesPrefix { get; private set; }
        public string Prefix { get; private set; }
        public bool UsesRange { get; private set; }
        public int? RangeMin { get; private set; }
        public int? RangeMax { get; private set; }
    }
}
