using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    public class productDetailModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        public productDetailModel(IProductService iProductService, ICatelogService iCatelogService)
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
        }
        public ProductModel productModel { get; set; }
        public async Task OnGetAsync()
        {
            // productModel = await _iProductService.GetByIdAsync(id);
        }
    }
}