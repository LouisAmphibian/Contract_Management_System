using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;


namespace TheGym.Models
{
    //Sign-Up Model Class
    public class SignUp
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
                    string query = "INSERT INTO users VALUES('" + username + "','" + email + "','" + pasword + "')";

                    //execute commandd to inssert user data into the database
                    using (SqlCommand command = new SqlCommand(query, sqlconnects))
                    {
                        //then execute the command
                        command.ExecuteNonQuery();

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
            catch (IOException error)
            {
                message = error.Message;
            }

            return message;
        }



    }
}
