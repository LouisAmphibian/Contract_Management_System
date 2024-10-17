using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class SignInSignUp
    {
        public SignInModel SignInModel { get; set; } = new SignInModel(); //instead of constructor
        public SignUpModel SignUpModel { get; set; } = new SignUpModel();

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

    //Sign-Up Class
    public class SignUpModel
    {
        //properties
        [Required (ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public Email? Email { get; set; }

        [Required (ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
