using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<IEnumerable<InvoiceDetailModel>> GetAllAsync();
        Task<PaginationList<InvoiceDetailModel>> GetPagesAsync(PaginationModel pagination);
        Task<InvoiceDetailModel> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDetailModel>> GetByInvoiceASync(int id);
        Task<InvoiceDetailModel> GetByProductAsync(int invoiceId, int productId);
        Task<bool> CreateAsync(InvoiceDetailModel obj);
        Task<bool> UpdateAsync(InvoiceDetailModel obj);
        Task<bool> DeleteAsync(int id);
    }
}