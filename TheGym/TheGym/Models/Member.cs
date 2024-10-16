using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class Member
    {
        //the properties that will be stored in the database
        public int MemberID { get; set; }  // Primary Key

        [MaxLength(100)] //Length for thr name field
        public string? Name { get; set; }    // Member Name

        [MaxLength(15)] //Length for thr name field
        public string? ContactDetails { get; set; } // Member Contact Detail
        public List<Contract> Contracts { get; set; }  // Relationship with Contracts

        [Required]
        public Email? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

}