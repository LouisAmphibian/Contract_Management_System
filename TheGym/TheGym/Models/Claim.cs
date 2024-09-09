using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class Claim
    {
        //the properties tha will be stored in the database
        public int ClaimID { get; set; }  // Primary Key
        public decimal ClaimAmount { get; set; }  // Claim amount
        public DateTime ClaimMonth { get; set; }  // Claim month

        public string? Status { get; set; }    // Claim status: Pending, Approved, Denied
        public int ContractID { get; set; }  // Foreign Key for Contract
        public Contract? Contract { get; set; }  // Relationship with Contract
        public List<Payment> Payments { get; set; }  // Relationship with Payments
    }

}