using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Microsoft.AspNetCore.Identity;

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
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Username { get; set; } = ""; //Will accept username and email

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Text)]
        public string Password { get; set; } = "";

       


        //MANGING the Database
        //Connection string class
        Connection connection = new Connection();

        //Method to check user
        public string LoginUser(string usernameOrEmail, string password)
        {
            //temp message
            string message = "";

            try
            {
                //connect and open
                using (SqlConnection sqlconnects = new SqlConnection(connection.connecting()))
                {
                    //open 
                    sqlconnects.Open();



                    //query 
                    string query;
                    //Retrieve to the sign up data
                    //Condtion to check if it is a email or username to run each specific query
                    if (usernameOrEmail.Contains("@")){
                        query = "SELECT * FROM users WHERE user_email = '" + usernameOrEmail + "' AND user_password ='" + password + "';";
                    }
                    else
                    {
                        query = "SELECT * FROM users WHERE user_name = '" + usernameOrEmail + "' AND user_password ='" + password + "';";
                    }

                    /*
                   //check if it recieves data"
                   Console.WriteLine(emaill + " AND " + password);
                   */

                    using (SqlCommand command = new SqlCommand(query, sqlconnects))
                    {
                        //To prevent SQL injection
                        command.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);
                        command.Parameters.AddWithValue("@password", password);
                       // command.Parameters.AddWithValue("@role", role);

                        //read the data
                        using (SqlDataReader find_user = command.ExecuteReader())
                        {

                            //then check if user is Found
                            if (find_user.HasRows)
                            {
                                find_user.Read();

                                string email = find_user["user_email"].ToString();

                                //check type of user is found
                                if (email.Contains(".pc@contractly.com"))
                                {
                                    message = "pc found";
                                }
                                else if (email.Contains(".pm@contractly.com"))
                                {
                                    message = "pm found";
                                }
                                else if (email.Contains(".hr@contractly.com"))
                                {
                                    message = "hr found";
                                }
                                else
                                {
                                    //true when found
                                    message = "found";
                                }
                                

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
