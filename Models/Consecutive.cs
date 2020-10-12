using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Models
{
    public class Consecutive
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }
        public string Table { get; private set; }
        public int Current { get; private set; }
        public string Prefix { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }
    }
}
