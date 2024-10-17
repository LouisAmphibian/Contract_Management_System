using Microsoft.AspNetCore.Mvc;
using TheGym.Models;
using TheGym.Services;



namespace TheGym.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        //list of members
        public List<Member> Members { get; set; } = new List<Member>();

        public UserController(ApplicationDbContext context)
        {
            this.context = context;

        }

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
                return RedirectToAction("Index", "UserController");
            }
            else
            {
                //Creating a new member 
                Member newMember = new Member()
                {
                    Name = signUp.SignUpModel.Name,
                    Email = signUp.SignUpModel.Email,
                    Password = signUp.SignUpModel.Password
                };

                context.Members.Add(newMember);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");

            }

        }


        //Get
        [HttpGet]
        public IActionResult SignIn() {


            return View();
        }
    }
}
