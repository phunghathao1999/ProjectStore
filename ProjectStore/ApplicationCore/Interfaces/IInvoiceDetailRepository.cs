using System.Threading.Tasks;
using ApplicationCore.Entity;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        Task<InvoiceDetail> GetByProductAsync(int invoiceId, int productID);
    }
}