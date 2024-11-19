using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheGym.Models;

namespace TheGym.Controllers
{
    public class AccountController : Controller
    {

        



        public IActionResult Index()
        {
            return View();
        }
    }
}
