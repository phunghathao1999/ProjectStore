using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPeoples()
        {
            return await _peopleService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeople(int id)
        {
            return await _peopleService.GetByIdAsync(id);
        }

        [HttpGet("/api/store/pages")]
        public async Task<IActionResult> GetPages([FromBody] PaginationModel paginationModel)
        {
            return await _peopleService.GetPagesAsync(paginationModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeople(PeopleModel peopleModel)
        {
            return await _peopleService.CreateAsync(peopleModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePeople(int id, PeopleModel peopleModel)
        {
            return await _peopleService.UpdateAsync(peopleModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePeople(int id)
        {
            return await _peopleService.DeleteAsync(id);
        }
    }
}
