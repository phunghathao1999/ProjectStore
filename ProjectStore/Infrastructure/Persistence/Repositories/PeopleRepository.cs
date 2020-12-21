using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository(StoreContext context) : base(context)
        {

        }
        protected new StoreContext Context => base.Context as StoreContext;

        public async Task<People> GetByEmailAsync(string email)
        {
            return await Context.People.SingleOrDefaultAsync(a => a.username.Equals(email));
        }
    }
}