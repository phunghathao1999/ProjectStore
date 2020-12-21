using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(StoreContext context) : base(context)
        {
            
        }
        protected new StoreContext Context => base.Context as StoreContext;
    }
}