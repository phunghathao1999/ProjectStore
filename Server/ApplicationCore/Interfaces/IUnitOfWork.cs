using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        public ICatelogRepository Catelog { get; }
        public IInvoiceRepository Invoice { get; }
        public IPeopleRepository People { get; }
        public IInvoiceDetailRepository InvoiceDetail { get; }
        public IProductRepository Product { get; }
        public IRoleRepository Role { get; }

        Task<int> CompleteAsync();
    }
}