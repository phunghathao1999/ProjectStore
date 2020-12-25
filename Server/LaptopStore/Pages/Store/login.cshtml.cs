using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Status;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LaptopStore.Pages.Store
{
    public class loginModel : PageModel
    {
        private readonly ILogger<loginModel> _logger;
        private readonly IPeopleService _service;
        public loginModel(ILogger<loginModel> logger, IPeopleService service)
        {
            _logger = logger;
            _service = service;
        }
        [BindProperty]
        public LoginModel login { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _service.LoginAsync(login);

                if (result)
                {
                    var people = await _service.GetByEmail(login.email);

                    if (people.Role.roleName == RoleName.CUSTOMER)
                    {
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                        new[] {
                            new Claim(ClaimTypes.Name, people.name),
                            new Claim(ClaimTypes.Email, people.username),
                            new Claim(ClaimTypes.Role, people.Role.roleName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToPage("/store/home");
                    }
                    else
                        ModelState.AddModelError("", "Tài khoảng không hợp lệ");
                }
                else
                    ModelState.AddModelError("", "Tài khoảng hoặc mật khẩu không đúng");
            }

            return Page();
        }
    }
}
