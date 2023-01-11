
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        public List<UserRole> UserRoles { get; set;}
        public List<PasswordReset> PasswordReset { get; set; }

        //public bool IsActive { get; set; }
        //public bool IsLocked { get; set; }
    }
}
