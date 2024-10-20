using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Entities;

namespace TestAssignment.DAL.DataAccessService
{
    public class ProductCategoryService
    {
        public ProductCategoryService() { }
        public async Task UpdateProductCategoryAsync(ProductCategory dbProductCategory, ProductCategory newProductCategory)
        {
            await Task.Run(() => UpdateProductCategory(dbProductCategory, newProductCategory));
        }
        public void UpdateProductCategory(ProductCategory dbProductCategory, ProductCategory newProductCategory)
        {
            dbProductCategory.Name = newProductCategory.Name;
            dbProductCategory.Description = newProductCategory.Description;
        }
    }
}
