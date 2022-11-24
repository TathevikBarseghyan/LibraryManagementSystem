using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Attributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var stringValue = value as string;

            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (regex.IsMatch(stringValue))
            {
                return true;
            }

            return false;
        }
    }
}
