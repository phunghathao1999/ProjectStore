using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LaptopStore.Pages.Store
{
    [Authorize(Roles = "Khách hàng")] 
    public class logoutModel : PageModel
    {
        public logoutModel()
        {
        }
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/store/home");
        }
    }
}
