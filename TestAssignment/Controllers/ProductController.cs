using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAssignment.DAL;
using TestAssignment.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using TestAssignment.AppCore.DTO.RequestDTO;
using TestAssignment.AppCore.DTO.ResponseDTO;
using TestAssignment.DAL.DataAccessService;
namespace TestAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        private TestAssignDbContext _dbcontext;
        private ProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(TestAssignDbContext dbcontext, ProductService service,  IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _productService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            var products = await _dbcontext.Products.ToListAsync();    
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponse>> Get(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return base.Ok(_mapper.Map<ProductResponse>(product));
        }

        [HttpGet("{id:int}/category")]
        public async Task<ActionResult<ProductCategoryResponse>> GetCategory(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var category =await _dbcontext.ProductCategories.FindAsync(product.CategoryId);
            return Ok(_mapper.Map<ProductCategoryResponse>(category));
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Post([FromBody] ProductRequest productDTO)
        {
            Product newProduct = _mapper.Map<Product>(productDTO);
            ProductCategory? category = await _dbcontext.ProductCategories.FindAsync(productDTO.CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            await _dbcontext.Products.AddAsync(newProduct);
            await _dbcontext.SaveChangesAsync();
            return base.Ok(_mapper.Map<ProductResponse>(newProduct));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductResponse>> Put(int id, [FromBody] ProductRequest productDTO)
        {
            Product newProduct = _mapper.Map<Product>(productDTO);
            ProductCategory? category = await _dbcontext.ProductCategories.FindAsync(productDTO.CategoryId);
            if (category == null)
            {
                return BadRequest();
            }
            Product? product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateProductAsync(product, newProduct);
            await _dbcontext.SaveChangesAsync();
            return Ok(_mapper.Map<ProductResponse>(product));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Product? product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }




    }
}
