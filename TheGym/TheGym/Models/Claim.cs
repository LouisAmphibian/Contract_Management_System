using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class Claim
    {
        //the properties tha will be stored in the database
        public int ClaimID { get; set; }  // Primary Key

        public int MemberID { get; set; }  // Foreign Key to Member
        public decimal ClaimAmount { get; set; }  // Claim amount


        [DataType(DataType.Date)] // Ensures date format
        public DateTime ClaimMonth { get; set; } // Date of the claim

        [MaxLength(500)]
        public string? ClaimDescription { get; set; } // Description of the claim

        public string? Status { get; set; }    // Claim status: Pending, Approved, Denied
        public int ContractID { get; set; }  // Foreign Key for Contract
        public Contract? Contract { get; set; }  // Relationship with Contract
        public List<Payment> Payments { get; set; }  // Relationship with Payments
    }

}