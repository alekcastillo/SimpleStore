using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.DAO
{
    public class user
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName1 { get; private set; }
        public string LastName2 { get; private set; }
        public List<UserRole> Roles { get; private set; }

        public user()
        {

        }

        public user(Guid id, string email, string password, string firstName, string lastName1, string lastName2, List<UserRole> roles)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Roles = roles;
        }

        public user(string email, string password, string firstName, string lastName1, string lastName2, List<UserRole> roles)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Roles = roles;
        }
    }
}
