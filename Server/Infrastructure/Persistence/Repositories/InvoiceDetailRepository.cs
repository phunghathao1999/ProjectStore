using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(StoreContext context) : base(context)
        {

        }
        protected new StoreContext Context => base.Context as StoreContext;

        public async Task<InvoiceDetail> GetByProductAsync(int invoiceId, int productID)
        {
            return await Context.InvoiceDetail.SingleOrDefaultAsync(a => (a.invoiceID == invoiceId && a.productID == productID));
        }
    }
}