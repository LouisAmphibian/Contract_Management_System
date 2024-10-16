using Microsoft.AspNetCore.Mvc;

namespace TheGym.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
