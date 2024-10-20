using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.ValidationRules;

namespace TestAssignment.AppCore.DTO.RequestDTO
{
    public class ProductCategoryRequest
    {
        [NotNullOrWhiteSpace]
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
