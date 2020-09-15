using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
