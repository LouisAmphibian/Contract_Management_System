namespace TheGym.Models
{
    public class Payment
    {
        //the properties tha will be stored in the database
        public int PaymentID { get; set; }  // Primary Key
        public decimal PaymentAmount { get; set; }  // Payment amount
        public DateTime PaymentDate { get; set; }  // Payment date
        public string PaymentMethod { get; set; }  // Payment method: Credit Card, Bank Transfer, etc.
        public string Status { get; set; }    // Payment status: Completed, Failed, Pending
        public int ClaimID { get; set; }  // Foreign Key for Claim
        public Claim Claim { get; set; }  // Relationship with Claim
    }

}