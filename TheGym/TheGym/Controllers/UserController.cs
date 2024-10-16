using Microsoft.AspNetCore.Mvc;
using TheGym.Models;

namespace TheGym.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Sign Up a new user
        [HttpPost]
        public IActionResult SignUp(SignInSignUp signUp)
        {
            // information about the model being validated.
            //If the model state is not valid
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "UserController1");
            }
            else
            {
                Member member = new Member();
                {
                    Name = signUp.
                }

            }
            return View();
        }


        //Get
        [HttpGet]
        public IActionResult SignIn() {


            return View();
        }
    }
}
