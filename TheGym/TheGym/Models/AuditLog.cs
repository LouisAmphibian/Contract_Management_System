using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class AuditLog
    {
        //the properties tha will be stored in the database
        public int AuditLogID { get; set; }  // Primary Key

        [MaxLength(100)] //Length for thr name field
        public string? Action { get; set; }   // Action performed
        public DateTime ActionDate { get; set; }  // Timestamp of the action
        public int AdminID { get; set; }  // Foreign Key for Administrator
        public Administrator Administrator { get; set; }  // Relationship with Administrator
    }

}
