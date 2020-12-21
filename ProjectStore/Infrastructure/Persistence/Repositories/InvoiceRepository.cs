using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Status;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(StoreContext context) : base(context)
        {

        }
        protected new StoreContext Context => base.Context as StoreContext;

        public async Task<Invoice> GetByStatusAsync(int peopleId, string status)
        {
            return await Context.Invoice.SingleOrDefaultAsync(a => a.customerID.Equals(peopleId) && a.status.Equals(status));
        }
    }
}
