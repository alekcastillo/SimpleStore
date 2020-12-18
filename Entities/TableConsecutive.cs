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
        public Guid Id { get; set; }
        public string Table { get; set; }
        public int Current { get; set; }
        public bool UsesPrefix { get; set; }
        public string Prefix { get; set; }
        public bool UsesRange { get; set; }
        public int? RangeMin { get; set; }
        public int? RangeMax { get; set; }

        public string GetCurrentCode()
        {
            var currentCode = "";

            if (UsesRange)
            {
                if (RangeMin != null && Current < RangeMin)
                    throw new ValidationException("The current is bellow the range's min");

                if (RangeMax != null && Current >= RangeMax)
                    throw new ValidationException("The current is above or equal to the range's max");
            }

            if (UsesPrefix)
                currentCode += $"{Prefix}-";

            currentCode += Current.ToString();
            Current += 1;

            return currentCode;
        }
    }
}
