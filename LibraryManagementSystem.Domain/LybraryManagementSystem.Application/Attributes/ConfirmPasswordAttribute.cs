using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Attributes
{
    public class ConfirmPasswordAttribute : ValidationAttribute
    {
        private readonly string _password;
        public ConfirmPasswordAttribute(string password)
        {
            _password = password;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            string comparisonPass = string.Empty;

            if(value is string convertedValue)
            {
                comparisonPass = convertedValue;
            }

            var property = validationContext.ObjectType.GetProperty(_password);

            if (property == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            if (!comparisonPass.Equals(property.GetValue(validationContext.ObjectInstance))) 
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
