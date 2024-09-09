using Microsoft.AspNetCore.Mvc;
using TheGym.Services;
using TheGym.Models;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class ClaimController : Controller
    {
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



    }

}