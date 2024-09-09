using Microsoft.AspNetCore.Mvc;
using TheGym.Services;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext context;

        //ctor
        public PaymentController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var payment = context.Payments.ToList();//converting all informaton/Data to a list

            return View(payment);
        }



    }

}