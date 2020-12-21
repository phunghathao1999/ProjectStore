using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceModel>> GetAllAsync();
        Task<PaginationList<InvoiceModel>> GetPagesAsync(PaginationModel pagination);
        Task<InvoiceModel> GetByIdAsync(int id);
        Task<InvoiceModel> GetByStatusAsync(int peopleId, string status);
        Task<IEnumerable<InvoiceModel>> GetByCustomerASync(int customerId);
        Task<bool> ChangeStatus(int id, string status);
        Task<bool> CreateAsync(InvoiceModel obj);
        Task<bool> UpdateAsync(InvoiceModel obj);
        Task<bool> DeleteAsync(int id);
    }
}