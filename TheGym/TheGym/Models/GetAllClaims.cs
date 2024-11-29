using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace TheGym.Models
{
    public class GetAllClaims
    {
        public List<ClaimDetail> Claims { get; set; } = new List<ClaimDetail>();
        private readonly Connection connection = new Connection();

        public GetAllClaims()
        {
            LoadAllClaims();
        }

        private void LoadAllClaims()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.connecting()))
                {
                    sqlConnection.Open();

                    // Fetch all claims from the database
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM claims", sqlConnection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Claims.Add(new ClaimDetail
                                {
                                    ClaimId = reader["claim_id"].ToString(),
                                    UserId = reader["user_id"].ToString(),
                                    ClaimerName = reader["claimer_name"].ToString(),
                                    ClaimerSurname = reader["claimer_surname"].ToString(),
                                    TypeOfClaim = reader["type_of_claim"].ToString(),
                                    ClaimDescription = reader["description"].ToString(),
                                    HoursWorked = reader["hours_worked"].ToString(),
                                    HourlyRate = reader["hourly_rate"].ToString(),
                                    TotalWorkClaim = reader["total_work_claim"].ToString(),
                                    DateFiled = reader["date_filled"].ToString(),
                                    AssignedTo = reader["assigned_to"].ToString(),
                                    Status = reader["status"].ToString(),
                                    DateResolved = reader["date_resolved"].ToString(),
                                    UserClaimContactEmail = reader["user_contact_email"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading claims: {ex.Message}");
            }
        }

        public class ClaimDetail
        {
            public string ClaimId { get; set; }
            public string UserId { get; set; }
            public string ClaimerName { get; set; }
            public string ClaimerSurname { get; set; }
            public string TypeOfClaim { get; set; }
            public string ClaimDescription { get; set; }
            public string HoursWorked { get; set; }
            public string HourlyRate { get; set; }
            public string TotalWorkClaim { get; set; }
            public string DateFiled { get; set; }
            public string AssignedTo { get; set; }
            public string Status { get; set; }
            public string DateResolved { get; set; }
            public string UserClaimContactEmail { get; set; }
        }
    }
}