using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Interfaces
{
    public interface ICatelogService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetPagesAsync(PaginationModel pagination);
        Task<IActionResult> GetByIdAsync(int id);
        Task<IActionResult> CreateAsync(CatelogModel obj);
        Task<IActionResult> UpdateAsync(CatelogModel obj);
        Task<IActionResult> DeleteAsync(int id);
    }
}