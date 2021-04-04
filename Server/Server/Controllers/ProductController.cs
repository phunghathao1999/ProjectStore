using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeoples()
        {
            var product = await _unitOfWork.Product.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(product));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeople(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });
            product.Catelog = await _unitOfWork.Catelog.GetByIdAsync(product.catelogID);
            return Ok(_mapper.Map<Product, ProductModel>(product));
        }

        [HttpGet("topselling")]
        public async Task<IActionResult> GetTopSellingASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.sale).Take(number);
            else
                products = products.OrderByDescending(p => p.createdDate).Take(number);

            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products));
        }

        [HttpGet("newproduct")]
        public async Task<IActionResult> GetNewProductASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.createdDate).Take(number);
            else
                products = products.OrderByDescending(p => p.createdDate).Take(number);

            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products));
        }

        [HttpGet("pages")]
        public async Task<IActionResult> GetPages(PaginationModel paginationModel)
        {

            var products = await _unitOfWork.Product.GetAllAsync();

            if (!string.IsNullOrEmpty(paginationModel.searchValue))
                products = products.Where(a =>
                    a.productName.ToLower().Contains(paginationModel.searchValue.ToLower()));

            if (!string.IsNullOrEmpty(paginationModel.catelogs))
            {
                List<String> catelogList = new List<String>();
                for (int i = 0; i < paginationModel.catelogs.Split(",").Length; i++)
                {
                    catelogList.Add(paginationModel.catelogs.Split(",")[i]);
                }
                products = products.Where(a => catelogList.Contains(a.catelogID.ToString()));
            }
            if ((paginationModel.fromPrice > 0 && paginationModel.toPrice == 0) || (paginationModel.fromPrice == 0 && paginationModel.toPrice > 0) || (paginationModel.fromPrice > 0 && paginationModel.toPrice > 0))
                products = products.Where(a => a.price >= paginationModel.fromPrice).Where(a => a.price <= paginationModel.toPrice);

            if (paginationModel.sort == "ASC")
                switch (paginationModel.sortKey)
                {
                    case "createdDate":
                        products = products.OrderBy(a => a.createdDate);
                        break;
                    case "price":
                        products = products.OrderBy(a => a.price);
                        break;
                    case "productName":
                        products = products.OrderBy(a => a.productName);
                        break;
                }

            if (paginationModel.sort == "DESC")
                switch (paginationModel.sortKey)
                {
                    case "createdDate":
                        products = products.OrderByDescending(a => a.createdDate);
                        break;
                    case "price":
                        products = products.OrderByDescending(a => a.price);
                        break;
                    case "productName":
                        products = products.OrderByDescending(a => a.productName);
                        break;
                }
            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);

            var productModels = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);

            return Ok(PaginationList<ProductModel>.Create(productModels, paginationModel.currentPage, paginationModel.pageSize));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePeople(ProductModel productModel)
        {
            var product = _mapper.Map<ProductModel, Product>(productModel);

            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Tạo thành công" });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePeople(int id, ProductModel productModel)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            _mapper.Map<ProductModel, Product>(productModel, product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, data = _mapper.Map<Product, ProductModel>(product), message = "Sửa thành công." });
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            await _unitOfWork.Product.RemoveAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Xóa thành công" });
        }

        //[HttpPost("addtocard")]
        //public async Task<IActionResult> AddToCard(int idEmployee, int idProduct)
        //{
        //    var peopleModel = await _unitOfWork.People.GetByIdAsync(idEmployee);
        //    if (peopleModel != null)
        //    {

        //        var oldInvoice = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
        //        if (oldInvoice != null)
        //        {
        //            var oldInvoiceDetail = await _invoiceDetailService.GetByProductAsync(oldInvoice.id, idProduct);
        //            if (oldInvoiceDetail != null)
        //            {
        //                oldInvoiceDetail.amount = oldInvoiceDetail.amount + 1;
        //                // oldInvoiceDetail.productID = productID;
        //                if (oldInvoiceDetail.Product.priceSale > 0)
        //                {
        //                    oldInvoiceDetail.price = oldInvoiceDetail.price + oldInvoiceDetail.Product.priceSale;
        //                    oldInvoice.totalMoney = oldInvoice.totalMoney + oldInvoiceDetail.Product.priceSale;
        //                }
        //                else
        //                {
        //                    oldInvoiceDetail.price = oldInvoiceDetail.price + oldInvoiceDetail.Product.price;
        //                    oldInvoice.totalMoney = oldInvoice.totalMoney + oldInvoiceDetail.Product.price;
        //                }

        //                await _invoiceDetailService.UpdateAsync(oldInvoiceDetail);
        //                await _invoiceService.UpdateAsync(oldInvoice);
        //            }
        //            else
        //            {
        //                var productModel = await _iProductService.GetByIdAsync(productID);

        //                InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
        //                invoiceDetailModel.productID = productID;
        //                invoiceDetailModel.amount = 1;
        //                invoiceDetailModel.invoiceID = oldInvoice.id;

        //                if (productModel.priceSale > 0)
        //                {
        //                    invoiceDetailModel.price = productModel.priceSale;
        //                    oldInvoice.totalMoney = oldInvoice.totalMoney + productModel.priceSale;
        //                }
        //                else
        //                {
        //                    invoiceDetailModel.price = productModel.price;
        //                    oldInvoice.totalMoney = oldInvoice.totalMoney + productModel.price;
        //                }
        //                await _invoiceDetailService.CreateAsync(invoiceDetailModel);
        //                await _invoiceService.UpdateAsync(oldInvoice);
        //            }

        //        }
        //        else
        //        {
        //            var productModel = await _iProductService.GetByIdAsync(productID);

        //            InvoiceModel newInvoice = new InvoiceModel();
        //            newInvoice.createdDate = DateTime.Now;
        //            newInvoice.customerID = peopleModel.id;
        //            newInvoice.status = InvoiceStatus.PROCESSING;
        //            newInvoice.totalMoney = productModel.priceSale;
        //            await _invoiceService.CreateAsync(newInvoice);

        //            InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
        //            invoiceDetailModel.productID = productID;
        //            invoiceDetailModel.amount = 1;
        //            invoiceDetailModel.price = productModel.priceSale * invoiceDetailModel.amount;
        //            var invoiceModel = await _invoiceService.GetByStatusAsync(peopleModel.id, InvoiceStatus.PROCESSING);
        //            invoiceDetailModel.invoiceID = invoiceModel.id;
        //            await _invoiceDetailService.CreateAsync(invoiceDetailModel);
        //        }
        //        return new JsonResult(true);
        //    }
        //    return new JsonResult(false);
        //}
    }
}
