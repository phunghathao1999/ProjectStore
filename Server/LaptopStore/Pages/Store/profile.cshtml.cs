using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Store
{
    [Authorize(Roles = "Khách hàng")] 
    public class profileModel : PageModel
    {
        public profileModel()
        {
        }
    }
}
