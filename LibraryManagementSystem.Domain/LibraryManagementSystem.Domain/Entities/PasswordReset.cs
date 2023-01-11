using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class PasswordReset
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GuId { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
