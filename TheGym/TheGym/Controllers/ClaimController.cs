using Microsoft.AspNetCore.Mvc;
using TheGym.Services;
using TheGym.Models;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class ClaimController : Controller
    {

        private readonly ILogger<UserController> _logger;

        public ClaimController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // This method returns the view for the create form.
        public IActionResult CreateClaim()
        {
            // This renders the view from Views/Home/CreateClaim.cshtml
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateClaim(Claim claimModel)
        {
            claimModel.DateFiled = DateTime.Now; // Capture the current date

            //assign
            string name = claimModel.Name;
            string surname = claimModel.Surname;
            string typeOfClaim = claimModel.TypeOfClaim;
            string claimDescription = claimModel.ClaimDescription;
            int hoursWorked = claimModel.HoursWorked;
            decimal hourlyRate = claimModel.HourlyRate;

            claimModel.DateFiled = DateTime.Now; // Capture the current date
            DateTime dateFiled = claimModel.DateFiled;

            IFormFile file = claimModel.File;


            if (!ModelState.IsValid)
            {
             foreach (var error in ModelState.Values.SelectMany(v=> v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Return view with validation errors
                return RedirectToAction("CreateClaim", "Claim", claimModel);
            }
           

            // This renders the view from Views/Home/CreateClaim.cshtml
            return View(claimModel);
        }





        /*
        private readonly ApplicationDbContext context;

        //ctor
        public ClaimController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var claim = context.Claims.ToList();//converting all informaton/Data to a list

            return View(claim);
        }

        // GET: Create Claim Form
        public IActionResult CreateClaim()
        {
            return View(); // Render the claim creation form
        }

        // POST: Create a New Claim
        [HttpPost]
        public IActionResult CreateClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                context.Claims.Add(claim); // Add the claim to the database
                context.SaveChanges();
                return RedirectToAction("Index"); // Redirect back to the index page after saving
            }
            return View(claim); // Return form with validation errors
        }

        */

    }

}