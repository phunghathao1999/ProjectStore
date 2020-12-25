using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    public class comboModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        public comboModel(IProductService iProductService, ICatelogService iCatelogService) 
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
        }
    }
}