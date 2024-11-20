using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using TheGym.Models;

namespace TheGym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //when index loads it must 1st check the connection
            try
            {
                //Connection string class
                Connection connection = new Connection();

                //open the connection
                using (SqlConnection sqlConnection = new SqlConnection(connection.connecting()))
                {
                    //Open the connection
                    sqlConnection.Open();
                    Console.WriteLine("Connected");
                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlError)
            {
                Console.WriteLine("Error: " + sqlError.Message);
            }
            catch (IOException error)
            {
                Console.WriteLine("Error: " + error.Message);
            }


            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
