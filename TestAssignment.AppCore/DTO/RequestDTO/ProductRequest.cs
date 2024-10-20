using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.ValidationRules;

namespace TestAssignment.AppCore.DTO.RequestDTO
{
    public class ProductRequest
    {
        [NotNullOrWhiteSpace]
        public string Name { get; set; }
        [NotNullOrWhiteSpace]
        public string Description { get; set; }
        [MinValue(0)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
