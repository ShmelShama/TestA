using Microsoft.AspNetCore.Mvc;
using TestAssignment.DAL;
using TestAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TestAssignment.AppCore.DTO.RequestDTO;
using TestAssignment.AppCore.DTO.ResponseDTO;
using AutoMapper;
using TestAssignment.DAL.DataAccessService;


namespace TestAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private TestAssignDbContext _dbcontext;
        private ProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        public ProductCategoryController(TestAssignDbContext dbcontext, ProductCategoryService service, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _productCategoryService = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryResponse>>> Get()
        {
            var productCategories = await _dbcontext.ProductCategories.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryResponse>>(productCategories));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCategoryResponse>> Get(int id)
        {
            var productCategory = await _dbcontext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return base.Ok(_mapper.Map<ProductCategoryResponse>(productCategory));
        }

        [HttpGet("{id:int}/products")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(int id)
        {
            var productCategory = await _dbcontext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            var products = await _dbcontext.Products.Where(p=>p.CategoryId==id).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products));
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryResponse>> Post([FromBody] ProductCategoryRequest productCategoryDTO)
        {
            ProductCategory newProductCategory = _mapper.Map<ProductCategory>(productCategoryDTO);
            await _dbcontext.ProductCategories.AddAsync(newProductCategory);
            await _dbcontext.SaveChangesAsync();
            return Ok(_mapper.Map<ProductCategoryResponse>(newProductCategory));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductCategoryResponse>> Put(int id, [FromBody] ProductCategoryRequest productCategoryDTO)
        {
            ProductCategory newProductCategory = _mapper.Map<ProductCategory>(productCategoryDTO);
            ProductCategory? productCategory = await _dbcontext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            await _productCategoryService.UpdateProductCategoryAsync(productCategory, newProductCategory);
            await _dbcontext.SaveChangesAsync();
            return Ok(_mapper.Map<ProductCategoryResponse>(productCategory));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            ProductCategory? productCategory = await _dbcontext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _dbcontext.ProductCategories.Remove(productCategory);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

    }
}
