using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    public class productModel : PageModel
    {
        private IProductService _iProductService;
        private ICatelogService _iCatelogService;
        public productModel(IProductService iProductService, ICatelogService iCatelogService)
        {
            _iProductService = iProductService;
            _iCatelogService = iCatelogService;
        }
        public async Task<IActionResult> OnGetPagination(int currentPage, string searchValue, int pageSize, string catelogs, string price, string sort)
        {
            PaginationModel paginationModel = new PaginationModel();
            if (!string.IsNullOrEmpty(sort))
            {
                paginationModel.sort = sort.Split("-")[1];
                paginationModel.sortKey = sort.Split("-")[0];
            }
            if (!string.IsNullOrEmpty(catelogs))
            {
                paginationModel.catelogs = catelogs;
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                paginationModel.searchValue = searchValue;
            }
            if (!string.IsNullOrEmpty(price))
            {
                if (price == "1000000")
                {
                    paginationModel.fromPrice = 0;
                    paginationModel.toPrice = Int32.Parse(price);
                }
                else
                {
                    if (price == "30000000")
                    {
                        paginationModel.fromPrice = Int32.Parse(price);
                    }
                    else
                    {
                        paginationModel.fromPrice = Int32.Parse(price.Split("-")[0]);
                        paginationModel.toPrice = Int32.Parse(price.Split("-")[1]);
                    }
                }
            }
            paginationModel.pageSize = pageSize;
            paginationModel.currentPage = currentPage;
            return new JsonResult(await _iProductService.GetPagesAsync(paginationModel));
        }
    }
}