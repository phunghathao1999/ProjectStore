using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    public class homeModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        public homeModel(IProductService iProductService, ICatelogService iCatelogService) 
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
        }

        public IEnumerable<ProductModel> newProduct;
        public IEnumerable<CatelogModel> catelogModels;

        public async Task OnGet() {
            catelogModels = await _iCatelogService.GetAllAsync();
        }

        public async Task<IActionResult> OnGetNewProduct(int id) {
            var products = await _iProductService.GetNewProductASync(id, 4);
            return new JsonResult(products);
        }

        public async Task<IActionResult> OnGetTopSelling(int id) {
            var products = await _iProductService.GetTopSellingASync(id, 4);
            return new JsonResult(products);
        }

        public async Task<IActionResult> OnGetCatelog() {
            var catelogModels = await _iCatelogService.GetAllAsync();
            return new JsonResult(catelogModels);
        }
    }
}