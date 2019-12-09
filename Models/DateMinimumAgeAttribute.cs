using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs_n_Dishes.Models
{
    public class DateMinimumAgeAttribute : ValidationAttribute
    {
        int MinimumAge;

        public DateMinimumAgeAttribute(int minimumAge)
        {
            MinimumAge = minimumAge;
            ErrorMessage = "{0} must be someone who is at least {1} years of age";
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            {
                return date.AddYears(MinimumAge) < DateTime.Now;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumAge);
        }
        
        public int minimumAge { get; }
    }
}