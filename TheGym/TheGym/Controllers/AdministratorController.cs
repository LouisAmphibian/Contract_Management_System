using Microsoft.AspNetCore.Mvc;
using TheGym.Services;

namespace TheGym.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext context;

        //ctor
        public AdministratorController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var admin = context.Administrators.ToList();//converting all informaton/Data to a list

            return View(admin);
        }



    }

}