using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    /*
    public class SignInSignUp
    {
        //creating a property
        [BindProperty]
        public SignInModel SignInModel { get; set; } = new SignInModel(); //instead of constructor

        [BindProperty]
        public SignUpModel SignUpModel { get; set; } = new SignUpModel();
    }
    */

    //Sign-In Class
    public class SignIn
    {
        //properties
        [Required(ErrorMessage = "Name or Email is required")]
        [MaxLength(100)]
        public string UserName { get; set; } = ""; //Will accept username and email

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        //MANGING the Database
        //Connection string class
        Connection connection = new Connection();

        //Method to check user
        public string LoginUser(string username, string password)
        {
            //temp message
            string message = "";

            try
            {
                //connect and open
                using (SqlConnection sqlonnects = new SqlConnection(connection.connecting()))
                {
                    //open 
                    sqlonnects.Open();

                    //query 
                    //Retrieve to the sign up data
                    string query = "SELECT * FROM users WHERE email = '" + username + "' and password ='" + password + "';";

                    using (SqlCommand command = new SqlCommand(query, sqlonnects))
                    {
                        //read the data
                        using (SqlDataReader find_user = command.ExecuteReader())
                        {

                            //then check if user is Found
                            if (find_user.HasRows)
                            {
                                //true when found
                                message = "found";

                            }
                            else
                            {
                                //false when found
                                message = "not";
                            }
                        }
                    }

                }


            }
            catch (SqlException sqlError)
            {
                message = sqlError.Message;
            }
            catch (IOException error)
            {
                message = error.Message;
            }
            return message;
        }
    }


}
