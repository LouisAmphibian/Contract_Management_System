using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace TheGym.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Logout()
        {
            //await HttpContext.SignOutAsync(); // Signs out the user
            return RedirectToAction("Index", "Home"); // Redirects to home or login page
        }
    }
}
