using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface ICatelogService
    {
        Task<IEnumerable<CatelogModel>> GetAllAsync();
        Task<PaginationList<CatelogModel>> GetPagesAsync(PaginationModel pagination);
        Task<CatelogModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(CatelogModel obj);
        Task<bool> UpdateAsync(CatelogModel obj);
        Task<bool> DeleteAsync(int id);
    }
}