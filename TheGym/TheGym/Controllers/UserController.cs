using Microsoft.AspNetCore.Mvc; //import mvc
using TheGym.Models; //import model
using TheGym.Services;
using System.Diagnostics;
using System.Data.SqlClient; //import SQL client



namespace TheGym.Controllers
{
    public class UserController : Controller
    {
        // private readonly ApplicationDbContext context;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //list of members
        public List<Member> Members { get; set; } = new List<Member>();

        /*
        public UserController(ApplicationDbContext context)
        {
            this.context = context;

        }
        */

        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        // This method returns the view for the sign-up form.
        public IActionResult SignUp()
        {
            return View();
        }



        //Sign Up a new user
        [HttpPost]
        [ActionName ("SignUp")]
       // [AcceptVerbs(HttpVerbs.Post]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignInSignUp signUp)
        {
            // Clear any validation errors for SignInModel since it's not used in the sign-up process
            ModelState.ClearValidationState(nameof(SignInSignUp.SignInModel));



            // information about the model being validated.
            //If the model state is not valid
            if (!TryValidateModel(signUp.SignUpModel, nameof(SignInSignUp.SignUpModel)))
            {
                /* 
                ModelState.AddModelError("", "Please check fields for errors");
                 return RedirectToAction("Index", "Home", signUp);
                */

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Return view with validation errors
                return RedirectToAction("Index", "Home", signUp);
            }

            /*
              //Creating a new member 
              Member newMember = new Member()
              {
                  Name = signUp.SignUpModel.UserName,
                  Email = signUp.SignUpModel.Email,
                  Password = signUp.SignUpModel.Password
              };
              */

            /*
            context.Members.Add(newMember);
            context.SaveChanges();
            */

            //Collect user data
            string user_name = signUp.SignUpModel.UserName;
            string user_email = signUp.SignUpModel.Email;
            string user_password = signUp.SignUpModel.Password;


            //check if all are collected
            Console.WriteLine("Name: " + user_name + "\nEmail: " + user_email + "\nPassword: " + user_password);

            // If the model state is invalid, return the same view and show validation errors
            return RedirectToAction("Index", "Home"); // Show the same page with validation errors
        }


        //Get
        [HttpGet]
        public IActionResult SignIn() {


            return View();
        }
    }
}
