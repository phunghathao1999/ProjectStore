using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Interfaces
{
    public interface IPeopleService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetPagesAsync(PaginationModel pagination);
        Task<IActionResult> GetByEmail(string email);
        Task<IActionResult> GetByIdAsync(int id);
        Task<IActionResult> CreateAsync(PeopleModel obj);
        Task<IActionResult> UpdateAsync(PeopleModel obj);
        Task<IActionResult> DeleteAsync(int id);
        Task<IActionResult> LoginAsync(LoginModel login);
    }
}