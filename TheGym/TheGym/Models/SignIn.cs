﻿using Microsoft.AspNetCore.Mvc;
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
        public string LoginUser(string email, string password)
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
                    string query = "SELECT * FROM users WHERE email = '" + email + "' and password ='" + password + "';";

                    /*
                   //check if it recieves data"
                   Console.WriteLine(emaill + " AND " + password);
                   */

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