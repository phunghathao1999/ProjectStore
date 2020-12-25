using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Catelog = new CatelogRepository(context);
            Combo = new ComboRepository(context);
            Invoice = new InvoiceRepository(context);
            People = new PeopleRepository(context);
            InvoiceDetail = new InvoiceDetailRepository(context);
            Product = new ProductRepository(context);
            Role = new RoleRepository(context);
        }

        public ICatelogRepository Catelog { get; }
        public IComboRepository Combo { get; }
        public IInvoiceRepository Invoice { get; }
        public IPeopleRepository People { get; }
        public IInvoiceDetailRepository InvoiceDetail { get; }
        public IProductRepository Product { get; }
        public IRoleRepository Role { get; }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}