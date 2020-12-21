using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<IEnumerable<ProductModel>> GetNewProductASync(int catelogID, int number = 10);
        Task<IEnumerable<ProductModel>> GetTopSellingASync(int catelogID, int number = 10);
        Task<PaginationList<ProductModel>> GetPagesAsync(PaginationModel pagination);
        Task<ProductModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(ProductModel obj);
        Task<bool> UpdateAsync(ProductModel obj);
        Task<bool> DeleteAsync(int id);
    }
}