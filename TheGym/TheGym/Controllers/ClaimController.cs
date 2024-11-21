using Microsoft.AspNetCore.Mvc;
using TheGym.Services;
using TheGym.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;


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
        public IActionResult CreateClaim(Claim claimModel, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Return view with validation errors
                return RedirectToAction("CreateClaim", "Claim", claimModel);
            }

            //assign
            string name = claimModel.Name;
            string surname = claimModel.Surname;
            string typeOfClaim = claimModel.TypeOfClaim;
            string claimDescription = claimModel.ClaimDescription;
            string hoursWorked = claimModel.HoursWorked.ToString();
            string hourlyRate = claimModel.HourlyRate.ToString();

            claimModel.DateFiled = DateTime.Now; // Capture the current date
            DateTime date = claimModel.DateFiled;
            string dateFiled = date.ToString("yyyy/MM/dd");

            string filename = "no file";

            //File info
            if (file != null && file.Length > 0)
            {
                //get file name
                filename = Path.GetFileName(file.FileName);

                //define
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, filename);

                //save the file to specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);

                    Console.WriteLine("File" + filename + "�s succesfully uploaded");
                }
            }

            /*
            //Check if collect
            Console.WriteLine($"Name: {name} \n Surname: {surname} \n Type of claim: {typeOfClaim} \n" +
                $"Claim Description: {claimDescription} \n Hour Worked: {hoursWorked} \n" +
                $"Hours Rate: {hourlyRate} \n File name: {filename} \nDate: {date}" );
            */

            //Insert the claaim in the database
            string message = claimModel.InsertClaim(name, surname, typeOfClaim, claimDescription, hoursWorked, hourlyRate, dateFiled, filename); 

            /*
            if(message == "done")
            {
                Console.WriteLine(message);
            }
            */

            // This renders the view from Views/Home/CreateClaim.cshtml
            return RedirectToAction("Dashboard","Dashboard");
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