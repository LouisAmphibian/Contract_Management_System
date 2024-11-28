using Microsoft.AspNetCore.Mvc;
using TheGym.Services;
using TheGym.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class ClaimController : Controller
    {

      

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

            // Capture the current date and format it as a string
            string dateFiled = DateTime.Now.ToString("yyyy/MM/dd");
            claimModel.DateFiled = dateFiled;
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

                    Console.WriteLine("File" + filename + "ïs succesfully uploaded");
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


            if (message == "done")
            {
                Console.WriteLine("Successfully added claim");
            }


            // This renders the view from Views/Home/CreateClaim.cshtml
            return RedirectToAction("Dashboard", "Dashboard");
        }

        // GET: Edit Claim
        public IActionResult EditClaim(int id)
        {
            // Fetch the claim from the database using the claim ID
            Claim claim = GetClaimById(id);

            if (claim == null)
            {
                return RedirectToAction("Dashboard", "Dashboard"); // Redirect if not found
            }

            return View(claim); // Return the view with the claim details
        }

        // POST: Edit Claim
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditClaim(int id, Claim claimModel)
        {
            if (!ModelState.IsValid)
            {
                return View(claimModel); // Return view with validation errors
            }

            // Fetch the existing claim to ensure ClaimId is set
            Claim existingClaim = GetClaimById(id);
            if (existingClaim == null)
            {
                ModelState.AddModelError("", "Claim not found.");
                return View(claimModel);
            }

            // Setting the ClaimId from the existing claim
            claimModel.ClaimId = existingClaim.ClaimId;

            // Update the claim in the database
            string message = UpdateClaim(claimModel);

            if (message != "done")
            {
                ModelState.AddModelError("", message); // Add error message if update fails
                return View(claimModel);
            }

            return RedirectToAction("Dashboard", "Dashboard"); // Redirect to the dashboard after editing
        }

        // GET: Delete Claim
        public IActionResult DeleteClaim(int id)
        {
            // Fetch the claim from the database using the claim ID
            Claim claim = GetClaimById(id);

            if (claim == null)
            {
                return RedirectToAction("Dashboard", "Dashboard"); // Redirect if not found
            }

            return View(claim); // Return the view with the claim details
        }



        
       


        // POST: Delete Claim
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Claim claim)
        {
            // Try to convert ClaimId to int
            if (int.TryParse(claim.ClaimId, out int claimId))
            {
                // Delete the claim from the database
                string message = DeleteClaimById(claimId);

                if (message != "done")
                {
                    ModelState.AddModelError("", message); // Add error message if delete fails
                    return RedirectToAction("Dashboard", "Dashboard");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Claim ID."); // Handle invalid ID
            }

            return RedirectToAction("Dashboard", "Dashboard"); // Redirect to the index after deletion
        }


        // Helper methods (implement these)
        private Claim GetClaimById(int id)
        {
            //get claimid method in your Claim class
            return new Claim().GetClaimById(id); // Assuming you have a method in your Claim class
        }

        private string UpdateClaim(Claim claim)
        {
            //UpdateClaim method in your Claim class
            return claim.UpdateClaim(claim);
        }

        private string DeleteClaimById(int id)
        {
            //DeleteClaim method in your Claim class
            return new Claim().DeleteClaim(id); 
        }
    }

}