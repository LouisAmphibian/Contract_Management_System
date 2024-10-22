﻿using Microsoft.AspNetCore.Mvc; //import mvc
using TheGym.Models; //import model
using TheGym.Services;
using System.Diagnostics;
using System.Data.SqlClient; //import SQL client



namespace TheGym.Controllers
{
    public class UserController : Controller
    {
        // private readonly ApplicationDbContext context;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //list of members
        public List<Member> Members { get; set; } = new List<Member>();

        /*
        public UserController(ApplicationDbContext context)
        {
            this.context = context;

        }
        */

        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        // This method returns the view for the sign-up form.
        public IActionResult SignUp()
        {
            return View();
        }



        //Sign Up a new user
        [HttpPost]
        [ActionName ("SignUp")]
       // [AcceptVerbs(HttpVerbs.Post]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUp signUpModel)
        {
            



            // information about the model being validated.
            //If the model state is not valid
            if (!ModelState.IsValid)
            {
                /* 
                ModelState.AddModelError("", "Please check fields for errors");
                 return RedirectToAction("Index", "Home", signUp);
                */

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Return view with validation errors
                return RedirectToAction("Index", "Home", signUpModel);
            }

            /*
              //Creating a new member 
              Member newMember = new Member()
              {
                  Name = signUp.SignUpModel.UserName,
                  Email = signUp.SignUpModel.Email,
                  Password = signUp.SignUpModel.Password
              };
              */

            /*
            context.Members.Add(newMember);
            context.SaveChanges();
            */

            //Collect user data
            string user_name = signUpModel.Username;
            string user_email = signUpModel.Email;
            string user_password = signUpModel.Password;

            /*
            //check if all are collected
            Console.WriteLine("Name: " + user_name + "\nEmail: " + user_email + "\nPassword: " + user_password);
            */

            //pass all values to insert method
            string message = signUpModel.InsertUser(user_name, user_email, user_password);

            //to check if the user inserted 
            if (message == "done")
            {
                //track error output
                Console.WriteLine(message);

                //Redirect  to index
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Console.WriteLine(message);

                // If the model state is invalid, return the same view and show validation errors
                return RedirectToAction("Index", "Home"); // Show the same page with validation errors
            }


           
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn signInModel)
        {
            // Check if either Username or Email is provided
            if (string.IsNullOrWhiteSpace(signInModel.Username) && string.IsNullOrWhiteSpace(signInModel.Email))
            {
                ModelState.AddModelError("", "Either Username or Email is required.");
            }

            if (!ModelState.IsValid)
            {

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Return view with validation errors
                return RedirectToAction("Index", "Home", signInModel);
            }

            //then assign 
            //to accept if it username or email
            string usernameOrEmail = !string.IsNullOrEmpty(signInModel.Username) ? signInModel.Username : signInModel.Email;
            
            //string email = signInModel.Email;
            string password = signInModel.Password;

            //pass the assign variables to the login user model methodd then check if it found
            string message = signInModel.LoginUser(usernameOrEmail, password);

            //Console.WriteLine($"Name/Email: {usernameOrEmail}, Password: {password}");
           
            //temp message

            if(message == "found")
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Index", "Home");

            }
        }

       
    }
}
