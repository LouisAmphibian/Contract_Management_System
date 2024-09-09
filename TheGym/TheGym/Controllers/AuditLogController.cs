using Microsoft.AspNetCore.Mvc;
using TheGym.Services;


//Controller used to control our back end
namespace TheGym.Controllers
{
    public class AuditLogController : Controller
    {
        private readonly ApplicationDbContext context;

        //ctor
        public AuditLogController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            //CRUDE (CREATE UPDTAE DELETE)

            var auditLog = context.AuditLogs.ToList();//converting all informaton/Data to a list

            return View(auditLog);
        }



    }

}