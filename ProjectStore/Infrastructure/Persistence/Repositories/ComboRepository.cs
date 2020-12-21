using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ComboRepository : Repository<Combo>, IComboRepository
    {
        public ComboRepository(StoreContext context) : base(context)
        {

        }
        protected new StoreContext Context => base.Context as StoreContext;

    }
}