using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Used to add audit fields to all tables
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
