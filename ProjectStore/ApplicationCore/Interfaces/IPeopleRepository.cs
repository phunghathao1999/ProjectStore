using System.Threading.Tasks;
using ApplicationCore.Entity;

namespace ApplicationCore.Interfaces
{
    public interface IPeopleRepository : IRepository<People>
    {
        Task<People> GetByEmailAsync(string email);
    }
}