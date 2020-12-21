using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Status;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    [Authorize(Roles = "Khách hàng")]
    public class profileInvoiceModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        private IInvoiceService _invoiceService;
        private IInvoiceDetailService _invoiceDetailService;
        private IPeopleService _iPeopleService;
        public profileInvoiceModel(IProductService iProductService, ICatelogService iCatelogService, IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService, IPeopleService peopleService)
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _iPeopleService = peopleService;
        }

        public IEnumerable<InvoiceModel> invoiceModels { get; set; }
        [BindProperty]
        public InvoiceModel invoiceModel { get; set; }

        public async Task OnGet()
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            var peopleModel = await _iPeopleService.GetByEmail(email);
            invoiceModels = await _invoiceService.GetByCustomerASync(peopleModel.id);
        }

        public async Task<IActionResult> OnPostCancelInvoice()
        {
            var obj = await _invoiceService.GetByIdAsync(invoiceModel.id);
            obj.status = InvoiceStatus.CANCEL;
            await _invoiceService.UpdateAsync(obj);
            return RedirectToPage("/store/profileInvoice");
        }
    }
}
