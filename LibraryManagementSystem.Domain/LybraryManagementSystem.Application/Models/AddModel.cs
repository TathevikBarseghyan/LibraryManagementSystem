using LybraryManagementSystem.Application.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models
{
    public class AddModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name can have 1-50 characters")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Fisrt Name can only have letters")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name can have 1-50 characters")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Last Name can only have letters")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Username can have 1-10 characters")]
        public string UserName { get; set; }

        //[EmailAddress(ErrorMessage ="Invalid Email Address")]
        [EmailValidation(ErrorMessage = "Invalid Email Address")]
        [DefaultValue("user@example.com")]
        public string Email { get; set; }

        [RegularExpression("^[A-Za-z0-9_*]*$", ErrorMessage = "Password  can only have letters, numbers, underscore and asterisk")]
        public string Password { get; set; }

        //[Compare("Password")]
        [Required(ErrorMessage ="Confirm your entered password")]
        [ConfirmPassword(("Password"), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
