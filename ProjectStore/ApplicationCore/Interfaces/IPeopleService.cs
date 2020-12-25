using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IPeopleService
    {
        Task<IEnumerable<PeopleModel>> GetAllAsync();
        Task<PaginationList<PeopleModel>> GetPagesAsync(PaginationModel pagination);
        Task<PeopleModel> GetByEmail(string email);
        Task<PeopleModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(PeopleModel obj);
        Task<bool> UpdateAsync(PeopleModel obj);
        Task<bool> DeleteAsync(int id);
        Task<bool> LoginAsync(LoginModel login);
    }
}