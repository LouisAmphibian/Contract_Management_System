using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class SignInSignUp
    {
        //creating a property
        [BindProperty]
        public SignInModel SignInModel { get; set; } = new SignInModel(); //instead of constructor

        //[BindProperty]
        public SignUpModel SignUpModel { get; set; } = new SignUpModel();

    }

    //Sign-Up Class
    public class SignUpModel
    {
        //properties
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Text)]
        public string Password { get; set; } = "";


        //MANGING the Database
        //Connection string class
        Connection connection = new Connection();

        //inserting data (method)
        public string InsertUser(string username, string email, string pasword)
        {
            //temp variable for message
            string message = "";

            //connect to database
            try
            {
                //open the connection
                using (SqlConnection sqlconnects = new SqlConnection(connection.connecting()))
                {
                    sqlconnects.Open();

                    //query
                    //Insert valuest to the database
                    string query = "INSERT INTO user VALUES('" + username + "','" + email + "','" + pasword + "')";

                    //execute commandd to inssert user data into the database
                    using (SqlCommand add_new_user = new SqlCommand(query, sqlconnects))
                    {
                        //then execute the command
                        add_new_user.ExecuteNonQuery();

                        message = "done";
                    }

                    //then close it
                    sqlconnects.Close();
                }

            }
            catch (SqlException sqlError)
            {
                message = sqlError.Message;
            }
            catch(IOException error)
            {
                message = error.Message;
            }

            return message;
        }

    }

    //Sign-In Class
    public class SignInModel
    {
        //properties
        [Required (ErrorMessage = "Name or Email is required")]
        [MaxLength(100)]
        public string? Name { get; set; } //Will accept username and email

        [Required (ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }


}
