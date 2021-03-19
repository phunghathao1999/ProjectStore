using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Interfaces
{
    public interface IProductService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetNewProductASync(int catelogID, int number = 10);
        Task<IActionResult> GetTopSellingASync(int catelogID, int number = 10);
        Task<IActionResult> GetPagesAsync(PaginationModel pagination);
        Task<IActionResult> GetByIdAsync(int id);
        Task<IActionResult> CreateAsync(ProductModel obj);
        Task<IActionResult> UpdateAsync(ProductModel obj);
        Task<IActionResult> DeleteAsync(int id);
        // Task<IActionResult> AddToCard(int idEmployee, int idProduct);
    }
}