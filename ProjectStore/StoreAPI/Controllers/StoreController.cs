using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IProductService _productService;
        public StoreController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productModel = await _productService.GetByIdAsync(id);
            if (productModel != null)
                return Ok(new { success = true, data = productModel });
            else
                return Ok(new { success = false, data = "", message = "Không tồn tại sản phẩm." });
        }

        [HttpGet("/api/store/pages")]
        public async Task<IActionResult> GetPages([FromBody] PaginationModel paginationModel)
        {
            return Ok( await _productService.GetPagesAsync(paginationModel));
        }

        [HttpGet("/api/store/newproduct/{id}")]
        public async Task<IActionResult> GetNewProduct(int id)
        {
            return Ok( await _productService.GetNewProductASync(id));
        }
        [HttpGet("/api/store/topselling/{id}")]
        public async Task<IActionResult> GetTOpSelling(int id)
        {
            return Ok( await _productService.GetTopSellingASync(id));
        }
    }
}
