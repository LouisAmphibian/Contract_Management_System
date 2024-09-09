namespace TheGym.Models
{
    public class Contract
    {
        //the properties tha will be stored in the database
        public int ContractID { get; set; }  // Primary Key
        public DateTime StartDate { get; set; }  // Contract Start Date
        public DateTime EndDate { get; set; }    // Contract End Date
        public decimal PaymentAmount { get; set; } // Payment amount per month
        public string? Status { get; set; }    // Contract status: Active, Expired, Canceled
        public int MemberID { get; set; }  // Foreign Key for Member
        public Member? Member { get; set; } // Relationship with Member
        public List<Claim> Claims { get; set; }  // Relationship with Claims
    }

}