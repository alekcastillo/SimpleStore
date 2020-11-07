using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Requirement 4.3.2, 5.2
    public class User : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public List<UserRole> Roles { get; set; }

        public User(Guid id, string email, string password, string firstName, string lastName1, string lastName2, List<UserRole> roles)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Roles = roles;
        }

        public User(string email, string password, string firstName, string lastName1, string lastName2, List<UserRole> roles)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Roles = roles;
        }

        public User(string email, string password, string firstName, string lastName1, string lastName2)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;        }

        public User()
        {

        }
    }
}
