using LybraryManagementSystem.Application.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models.User
{
    public class PasswordResetModel
    {
        [RegularExpression("^[A-Za-z0-9_*]*$", ErrorMessage = "Password  can only have letters, numbers, underscore and asterisk")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your entered password")]
        [ConfirmPassword("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        //public int UserId { get; set; }
        //public string GuId { get; set; }
        //public DateTime Date { get; set; }
    }
}
