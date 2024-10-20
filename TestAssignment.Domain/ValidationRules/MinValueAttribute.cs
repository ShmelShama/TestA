using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment.Domain.ValidationRules
{
    public class MinValueAttribute: ValidationAttribute
    {
        private readonly double _minValue;

        public MinValueAttribute(double minValue)
        {
            _minValue = minValue;
            ErrorMessage = "Enter a value equal or greater than " + _minValue;
        }

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
            ErrorMessage = "Enter a value equal or greater than " + _minValue;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return Convert.ToDouble(value) >= _minValue;
        }
    }
}
