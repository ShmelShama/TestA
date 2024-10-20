using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment.Domain.ValidationRules
{
    public class NotNullOrWhiteSpaceAttribute: ValidationAttribute
    {
        public NotNullOrWhiteSpaceAttribute() 
        {
            ErrorMessage = "Value cannot be empty or white space";
        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            if(string.IsNullOrWhiteSpace(value.ToString())) return false;
            return true;
        }


    }
}
