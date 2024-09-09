using Microsoft.AspNetCore.Mvc;
using TheGym.Services;

namespace TheGym.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext context;

        //ctor
        public ContractController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var contract = context.Contracts.ToList();//converting all informaton/Data to a list

            return View(contract);
        }



    }
}
