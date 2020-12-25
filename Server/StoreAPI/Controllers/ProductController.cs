using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpGet("/api/store/pages")]
        public async Task<IActionResult> GetPages([FromBody] PaginationModel paginationModel)
        {
            return await _productService.GetPagesAsync(paginationModel);
        }

        [HttpGet("/api/store/newproduct/{id}")]
        public async Task<IActionResult> GetNewProduct(int id)
        {
            return await _productService.GetNewProductASync(id);
        }
        [HttpGet("/api/store/topselling/{id}")]
        public async Task<IActionResult> GetTOpSelling(int id)
        {
            return await _productService.GetTopSellingASync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel productModel)
        {
            return await _productService.CreateAsync(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, ProductModel productModel)
        {
            return await _productService.UpdateAsync(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _productService.DeleteAsync(id);
        }
    }
}
