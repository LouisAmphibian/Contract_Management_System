using System.ComponentModel.DataAnnotations;

namespace TheGym.Models
{
    public class Administrator
    {
        //the properties tha will be stored in the database
        public int AdminID { get; set; }  // Primary Key

        [MaxLength(100)] //Length for thr name field
        public string? Name { get; set; }   // Administrator Name

        [MaxLength(100)]
        public string? Role { get; set; }    // Role: Finance Manager, Claims Processor

        public List<AuditLog> AuditLogs { get; set; }  // Relationship with Audit Logs
    }

}