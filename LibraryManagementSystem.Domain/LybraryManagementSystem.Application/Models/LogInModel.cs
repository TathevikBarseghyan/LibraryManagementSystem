using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models
{
    public class LogInModel
    {
        public string UserName { get; set; }

        [RegularExpression("^[A-Za-z0-9_*]*$", ErrorMessage = "Password  can only have letters, numbers, underscore and asterisk")]
        public string Password { get; set; }
    }
}
