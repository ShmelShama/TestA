using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Entities;
namespace TestAssignment.DAL.DataAccessService
{
    public class ProductService
    {
        public ProductService() { }
        public async Task UpdateProductAsync(Product dbProduct, Product newProduct)
        {
            await Task.Run(()=>UpdateProduct(dbProduct,newProduct));
        }
        public void UpdateProduct(Product dbProduct, Product newProduct)
        {
            dbProduct.Name = newProduct.Name;
            dbProduct.Description = newProduct.Description;
            dbProduct.Price = newProduct.Price;
            dbProduct.CategoryId = newProduct.CategoryId;
        }
    }
}
