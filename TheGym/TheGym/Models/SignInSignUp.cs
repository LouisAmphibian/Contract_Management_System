using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class SignInSignUp
    {
        public SignInModel SignInModel { get; set; } = new SignIn();
        public SignUpModel SignUpModel { get; set; } = new SignUp();

    }

    //Sign-In Class
    public class SignInModel
    {
        //properties
        [Required]
        public string? Name { get; set; } //Will accept username and email

        [Required]
        public string? Password { get; set; }
    }

    //Sign-Up Class
    public class SignUpModel
    {
        //properties
        [Required]
        public string? Name { get; set; }

        [Required]
        public Email? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
