using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace TheGym.Controllers
{
    public class DashboardController : Controller
    {
        //Normal user
        public IActionResult Dashboard()
        {
            //when the dashboard loads it must check the connection
            try
            {
                Connection connection = new Connection();

                using (SqlConnection sqlconnection = new SqlConnection(connection.connecting()))
                {
                    sqlconnection.Open();
                    Console.WriteLine("Connected");
                    sqlconnection.Close();
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

        //PC 
        public IActionResult PCAdminDashboard()
        {
            //when the dashboard loads it must check the connection
            try
            {
                Connection connection = new Connection();

                using (SqlConnection sqlconnection = new SqlConnection(connection.connecting()))
                {
                    sqlconnection.Open();
                    Console.WriteLine("Connected");
                    sqlconnection.Close();
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


        //PMAdminDashboard
        public IActionResult PMAdminDashboard()
        {
            //when the dashboard loads it must check the connection
            try
            {
                Connection connection = new Connection();

                using (SqlConnection sqlconnection = new SqlConnection(connection.connecting()))
                {
                    sqlconnection.Open();
                    Console.WriteLine("Connected");
                    sqlconnection.Close();
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

        //Hr
        public IActionResult HRAdminDashboard()
        {
            //when the dashboard loads it must check the connection
            try
            {
                Connection connection = new Connection();

                using (SqlConnection sqlconnection = new SqlConnection(connection.connecting()))
                {
                    sqlconnection.Open();
                    Console.WriteLine("Connected");
                    sqlconnection.Close();
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
    }
}
