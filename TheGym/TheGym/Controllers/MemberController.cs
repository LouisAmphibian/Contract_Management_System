using Microsoft.AspNetCore.Mvc;
using TheGym.Services;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext context;

        //ctor
        public MemberController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var member = context.Members.ToList();//converting all informaton/Data to a list

            return View(member);
        }



    }

}