using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        // Get: api/home
        // [HttpGet]
        // public ActionResult GetHome([FromQuery] PaginationModel pagination)
        // {
        //     var 

        //     return Ok (new { success = true, data = ticket });
        // }
    }
}
