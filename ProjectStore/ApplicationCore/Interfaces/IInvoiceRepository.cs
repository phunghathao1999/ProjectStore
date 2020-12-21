using System.Threading.Tasks;
using ApplicationCore.Entity;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> GetByStatusAsync(int peopleId, string status);
    }
}