using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheGym.Models
{
    public class GetClaims
    {
        public List<ClaimDetail> Claims { get; set; } = new List<ClaimDetail>();

        private readonly Connection connection = new Connection();

        public GetClaims()
        {
            try
            {
                string userId = GetUserId();
                if (!string.IsNullOrEmpty(userId))
                {
                    string email = GetUserEmail(userId);
                    if (!string.IsNullOrEmpty(email))
                    {
                        LoadClaims(email);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetClaims constructor: {ex.Message}");
            }
        }

        private string GetUserId()
        {
            string holdId = "";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.connecting()))
                {
                    sqlConnection.Open();
                    string email = DataManager.Instance.Data;
                    Console.WriteLine($"Fetching claims for email: {email}");

                    using (SqlCommand cmd = new SqlCommand("SELECT user_id FROM users WHERE user_email = @Email", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                holdId = reader["user_id"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user ID: {ex.Message}");
            }
            return holdId;
        }

        private string GetUserEmail(string userId)
        {
            string holdEmail = "";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.connecting()))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT user_email FROM users WHERE user_id = @UserId", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                holdEmail = reader["user_email"].ToString();
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user email: {ex.Message}");
            }
            return holdEmail;
        }

        private void LoadClaims(string email)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.connecting()))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM claims WHERE user_contact_email = @Email", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

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

                                Console.WriteLine($"Claims loaded: {Claims.Count}");
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
