using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Status;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopStore.Pages.Manegement
{
    [Authorize(Roles = "Quản lý")]
    public class homeModel : PageModel
    { 
        
        public homeModel()
        {

        }
    }
}
