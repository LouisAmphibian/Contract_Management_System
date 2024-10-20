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
    }


}
