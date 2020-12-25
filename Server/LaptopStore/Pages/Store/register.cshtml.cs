using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LaptopStore.Pages.Store
{
    public class registerModel : PageModel
    {

        private readonly ILogger<loginModel> _logger;
        private readonly IPeopleService _service;
        public registerModel(ILogger<loginModel> logger, IPeopleService service)
        {
            _logger = logger;
            _service = service;
        }
        [BindProperty]
        public PeopleModel peopleModel { get; set; }

        public async Task<IActionResult> OnPostAsync(){
            return Page();
        }
    }
}
