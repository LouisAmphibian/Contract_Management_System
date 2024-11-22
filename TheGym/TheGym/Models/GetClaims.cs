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
        //the properties tha will be retrieved in the database
        public List<ClaimDetail> Claims { get; set; } = new List<ClaimDetail>();

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


        Connection connection = new Connection();

        //Method to get claims
        public GetClaims()
        {
            

            //use 3 using
            try
            {
                string id = getId();
                string email = getEmail(id);

                using (SqlConnection connects = new SqlConnection(connection.connecting()))
                {
                    //open connection
                    connects.Open();

                    string query = "SELECT * FROM claims;";

                    using (SqlCommand prepare = new SqlCommand(query, connects))
                    {
                        using (SqlDataReader getEmail = prepare.ExecuteReader())
                        {
                            Console.WriteLine("getEmail");
                            while (getEmail.Read())
                            {
                                    
                                    //then get id
                                    // hold_email = getEmail["email"].ToString();
                                    ClaimDetail claim = new ClaimDetail
                                    {
                                        /*ClaimId.Add(getEmail["claim_id"].ToString());
                                        UserId.Add(getEmail["user_id"].ToString());
                                        ClaimerName.Add(getEmail["claimer_name"].ToString());
                                        ClaimerSurname.Add(getEmail["claimer_surname"].ToString());
                                        TypeOfClaim.Add(getEmail["type_of_claim"].ToString());
                                        ClaimDescription.Add(getEmail["description"].ToString());
                                        HoursWorked.Add(getEmail["hours_worked"].ToString());
                                        HourlyRate.Add(getEmail["hourly_rate"].ToString());
                                        TotalWorkClaim.Add(getEmail["total_work_claim"].ToString());
                                        DateFiled.Add(getEmail["date_filled"].ToString());
                                        AssignedTo.Add(getEmail["assigned_to"].ToString());
                                        Status.Add(getEmail["status"].ToString());
                                        DateResolved.Add(getEmail["date_resolved"].ToString());
                                        UserClaimContactEmail.Add(getEmail["user_contact_email"].ToString());*/

                                        ClaimId = getEmail["claim_id"].ToString(),
                                        UserId = getEmail["user_id"].ToString(),
                                        ClaimerName = getEmail["claimer_name"].ToString(),
                                        ClaimerSurname = getEmail["claimer_surname"].ToString(),
                                        TypeOfClaim = getEmail["type_of_claim"].ToString(),
                                        ClaimDescription = getEmail["description"].ToString(),
                                        HoursWorked = getEmail["hours_worked"].ToString(),
                                        HourlyRate = getEmail["hourly_rate"].ToString(),
                                        TotalWorkClaim = getEmail["total_work_claim"].ToString(),
                                        DateFiled = getEmail["date_filled"].ToString(),
                                        AssignedTo = getEmail["assigned_to"].ToString(),
                                        Status = getEmail["status"].ToString(),
                                        DateResolved = getEmail["date_resolved"].ToString(),
                                        UserClaimContactEmail = getEmail["user_contact_email"].ToString()
                                    };

                                    Claims.Add(claim);
                                
                            }

                            getEmail.Close();
                        }
                    }

                    connects.Close();
                }
            }
            catch (SqlException sqlError)
            {
                Console.WriteLine(sqlError.Message); 
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message); 
            }
        }

        public string getEmail(string user_Id)
        {
            //hold the email
            string hold_email = "";

            try
            {
                using (SqlConnection sqlconnects = new SqlConnection(connection.connecting()))
                {
                    //open connection
                    sqlconnects.Open();

                    using (SqlCommand sqlcommand = new SqlCommand($"SELECT user_email FROM users WHERE user_Id = {user_Id} ;", sqlconnects))
                    {
                        //prepare.Parameters.AddWithValue("@user_Id", user_Id);

                        using (SqlDataReader getEmail = sqlcommand.ExecuteReader())
                        {
                            if (getEmail.Read())
                            {
                                //check all but one

                                // then get email
                                hold_email = getEmail["user_email"].ToString();

                            }

                            getEmail.Close();
                        }
                    }

                    sqlconnects.Close();
                }
            }
            catch (SqlException sqlError)
            {

            }
            catch (IOException error)
            {

            }
            return hold_email;
        }



        public string getId()
        {
            //hold the id
            string hold_id = "";

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connection.connecting()))
                {
                    //open connection
                    sqlconnection.Open();

                    //Retrieve
                    string email = DataManager.Instance.Data;

                    //finding the id with user email
                    using (SqlCommand sqlcommand = new SqlCommand("SELECT user_id FROM users WHERE user_email = '" + email + "';", sqlconnection))
                    {
                        // prepare.Parameters.AddWithValue("@email", email);

                        // Execute reader
                        using (SqlDataReader getId = sqlcommand.ExecuteReader())
                        {

                            if (getId.Read())
                            {
                                //then get id
                                hold_id = getId["user_id"].ToString();
                            }

                            getId.Close();
                        }
                    }

                    sqlconnection.Close();
                }
            }
            catch (SqlException error)
            {
                Console.WriteLine("SQL Error: " + error.Message);
                hold_id = error.Message;
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_id = error.Message;
            }

            return hold_id;
        }

    }
}
