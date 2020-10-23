using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Used to create category-like tables
    public class BaseCategoryEntity : BaseEntity
    {
        public string Name { get; private set; }
    }
}
