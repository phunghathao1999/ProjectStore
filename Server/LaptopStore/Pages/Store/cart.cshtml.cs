using System;
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
    public class cartModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        private IInvoiceService _invoiceService;
        private IInvoiceDetailService _invoiceDetailService;
        private IPeopleService _iPeopleService;
        public cartModel(IProductService iProductService, ICatelogService iCatelogService, IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService, IPeopleService peopleService)
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _iPeopleService = peopleService;
        }

        [BindProperty]
        public InvoiceModel invoiceModel { get; set; }
        public PeopleModel peopleVM { get; set; }
        public InvoiceModel invoiceVM { get; set; }
        public IEnumerable<InvoiceDetailModel> invoiceDetailModels { get; set; }

        public async Task OnGetAsync()
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            peopleVM = await _iPeopleService.GetByEmail(email);
            invoiceVM = await _invoiceService.GetByStatusAsync(peopleVM.id, InvoiceStatus.PROCESSING);
            if (invoiceVM != null)
            {
                invoiceDetailModels = await _invoiceDetailService.GetByInvoiceASync(invoiceVM.id);
            }

        }

        public async Task<IActionResult> OnGetInvoice()
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            var peopleModel = await _iPeopleService.GetByEmail(email);
            return new JsonResult(await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING));
        }

        public async Task<IActionResult> OnGetInvoiceDetail()
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            var peopleModel = await _iPeopleService.GetByEmail(email);
            var invoiceModel = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
            return new JsonResult(await _invoiceDetailService.GetByInvoiceASync(invoiceModel.id));
        }

        public async Task<IActionResult> OnGetAddProductToCart(int productID)
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            var peopleModel = await _iPeopleService.GetByEmail(email);
            if (peopleModel != null)
            {

                var oldInvoice = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
                if (oldInvoice != null)
                {
                    var oldInvoiceDetail = await _invoiceDetailService.GetByProductAsync(oldInvoice.id, productID);
                    if (oldInvoiceDetail != null)
                    {
                        oldInvoiceDetail.amount = oldInvoiceDetail.amount + 1;
                        // oldInvoiceDetail.productID = productID;
                        if (oldInvoiceDetail.Product.priceSale > 0)
                        {
                            oldInvoiceDetail.price = oldInvoiceDetail.price + oldInvoiceDetail.Product.priceSale;
                            oldInvoice.totalMoney = oldInvoice.totalMoney + oldInvoiceDetail.Product.priceSale;
                        }
                        else
                        {
                            oldInvoiceDetail.price = oldInvoiceDetail.price + oldInvoiceDetail.Product.price;
                            oldInvoice.totalMoney = oldInvoice.totalMoney + oldInvoiceDetail.Product.price;
                        }

                        await _invoiceDetailService.UpdateAsync(oldInvoiceDetail);
                        await _invoiceService.UpdateAsync(oldInvoice);
                    }
                    else
                    {
                        var productModel = await _iProductService.GetByIdAsync(productID);

                        InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
                        invoiceDetailModel.productID = productID;
                        invoiceDetailModel.amount = 1;
                        invoiceDetailModel.invoiceID = oldInvoice.id;

                        if (productModel.priceSale > 0)
                        {
                            invoiceDetailModel.price = productModel.priceSale;
                            oldInvoice.totalMoney = oldInvoice.totalMoney + productModel.priceSale;
                        }
                        else
                        {
                            invoiceDetailModel.price = productModel.price;
                            oldInvoice.totalMoney = oldInvoice.totalMoney + productModel.price;
                        }
                        await _invoiceDetailService.CreateAsync(invoiceDetailModel);
                        await _invoiceService.UpdateAsync(oldInvoice);
                    }

                }
                else
                {
                    var productModel = await _iProductService.GetByIdAsync(productID);

                    InvoiceModel newInvoice = new InvoiceModel();
                    newInvoice.createdDate = DateTime.Now;
                    newInvoice.customerID = peopleModel.id;
                    newInvoice.status = InvoiceStatus.PROCESSING;
                    if (productModel.priceSale > 0)
                    {
                        newInvoice.totalMoney = productModel.priceSale;
                    }
                    else
                    {
                        newInvoice.totalMoney = productModel.price;
                    }
                    await _invoiceService.CreateAsync(newInvoice);

                    InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
                    invoiceDetailModel.productID = productID;
                    invoiceDetailModel.amount = 1;

                    if (productModel.priceSale > 0)
                    {
                        invoiceDetailModel.price = productModel.priceSale * invoiceDetailModel.amount;
                    }
                    else
                    {
                        invoiceDetailModel.price = productModel.price * invoiceDetailModel.amount;
                    }
                    var invoiceModel = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
                    invoiceDetailModel.invoiceID = invoiceModel.id;
                    await _invoiceDetailService.CreateAsync(invoiceDetailModel);
                }
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }

        public async Task<IActionResult> OnGetChangeAmount(int invoideDetailId, int amount)
        {
            string mess = "Thay đổi thành công";
            var invoiceDetailModel = await _invoiceDetailService.GetByIdAsync(invoideDetailId);
            var invoiceModel = await _invoiceService.GetByIdAsync(invoiceDetailModel.invoiceID);
            if (amount == 0)
            {
                if (invoiceModel.status.Equals(InvoiceStatus.PROCESSING))
                {
                    invoiceModel.totalMoney = invoiceModel.totalMoney - invoiceDetailModel.price * invoiceDetailModel.amount;
                    await _invoiceDetailService.DeleteAsync(invoiceDetailModel.id);
                    await _invoiceService.UpdateAsync(invoiceModel);
                }
            }
            if (amount > 0)
            {
                invoiceModel.totalMoney = invoiceModel.totalMoney + (amount - invoiceDetailModel.amount) * (invoiceDetailModel.price / invoiceDetailModel.amount);
                invoiceDetailModel.price = (invoiceDetailModel.price / invoiceDetailModel.amount) * amount;
                invoiceDetailModel.amount = amount;
                await _invoiceDetailService.UpdateAsync(invoiceDetailModel);
                await _invoiceService.UpdateAsync(invoiceModel);
            }

            return new JsonResult(mess);
        }

        public async Task<IActionResult> OnGetDeleteInvoiceDetail(int invoiceDetailId)
        {
            string mess = "Xóa thành công";
            var invoiceDetailModel = await _invoiceDetailService.GetByIdAsync(invoiceDetailId);

            var oldInvoice = await _invoiceService.GetByIdAsync(invoiceDetailModel.invoiceID);
            if (oldInvoice.status.Equals(InvoiceStatus.PROCESSING))
            {
                oldInvoice.totalMoney = oldInvoice.totalMoney - invoiceDetailModel.price * invoiceDetailModel.amount;
                await _invoiceDetailService.DeleteAsync(invoiceDetailModel.id);
                await _invoiceService.UpdateAsync(oldInvoice);
            }

            return new JsonResult(mess);
        }

        public async Task<IActionResult> OnPostConfimedInvoice()
        {
            string email = @User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            var peopleModel = await _iPeopleService.GetByEmail(email);
            var _invoiceModel = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
            _invoiceModel.status = InvoiceStatus.CONFIMED;
            _invoiceModel.customerName = invoiceModel.customerName;
            _invoiceModel.customerAddesss = invoiceModel.customerAddesss;
            _invoiceModel.phone = invoiceModel.phone;
            _invoiceModel.note = invoiceModel.note;
            await _invoiceService.UpdateAsync(_invoiceModel);
            return RedirectToPage("/store/profileInvoice");
        }

    }
}