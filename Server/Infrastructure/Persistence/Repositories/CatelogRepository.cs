using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CatelogRepository : Repository<Catelog>, ICatelogRepository
    {
        public CatelogRepository(StoreContext context) : base(context)
        {
            
        }
        protected new StoreContext Context => base.Context as StoreContext;
    }
}