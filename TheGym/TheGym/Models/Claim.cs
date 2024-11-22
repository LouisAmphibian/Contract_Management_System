using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace TheGym.Models
{
    public class Claim
    {
        //the properties tha will be stored in the database

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Surname is required")]
        [DataType(DataType.Text)]
        public string Surname { get; set; } = "";

        [Required(ErrorMessage = "Type Of Claim is required")]
        [DataType(DataType.Text)]
        public string TypeOfClaim { get; set; } = "";

        /// <summary>
        [Required(ErrorMessage = "Type Of Claim is required")]
        /// </summary>
        [DataType(DataType.Text)]
        [MaxLength(250, ErrorMessage = "Claim description cannot exceed 500 characters")]
        public string ClaimDescription { get; set; } = "";

        [Required(ErrorMessage = "Hours worked are required")]
        [Range(1, 24, ErrorMessage = "Hours worked must be between 1 and 24")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Hourly rate must be between 0.01 and 1000.00")]
        public decimal HourlyRate { get; set; }

        //[Required(ErrorMessage = "Claim amount is required")]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Claim amount must be greater than 0")]
        public decimal ClaimAmount { get; set; }  // Claim amount

        [Required(ErrorMessage = "Claim month is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DateFiled { get; set; } // Date of the claim

        //[Required(ErrorMessage = "Status is required")]
        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public string Status { get; set; } = "";   // Claim status: Pending, Approved, Denied

        [Display(Name = "Upload File")]
        public IFormFile? File { get; set; }

        //[Required(ErrorMessage = "Member ID is required")]
        public int MemberID { get; set; }  // Foreign Key to Member

        // [Required(ErrorMessage = "Contract ID is required")]
        public int ContractID { get; set; }  // Foreign Key for Contract

        public Contract? Contract { get; set; }  // Relationship with Contract

        // public List<Payment> Payments { get; set; }  // Relationship with Payments




        Connection connection = new Connection();

        //Method to insert claim
        public string InsertClaim(string name, string surname, string typeOfClaim, string description, string hours, string hourlyRate, string datefiled, string filename)
        {
            //temp message
            string message = "";

            //to get user data
            string user_Id = getId();
            string user_Email = getEmail(user_Id);

            string total_work_claim = "" + decimal.Parse(hours) * decimal.Parse(hourlyRate);
            //Console.WriteLine(total);
            string assignedTo = "Jake"; 
            string status = "pending";

            Console.WriteLine($"User email: {user_Email} \nUser id: {user_Id} \nName: {name} \nSurname: {surname} \nType Of Claim: {typeOfClaim} " +
                $"\nDescription: {description} \nHours: {hours} \nHourly Rate: {hourlyRate} \nDate: {datefiled} \nFile Name: {filename} \nTotal: {total_work_claim}");


            string query = "INSERT INTO claims (user_id, claimer_name, claimer_surname, type_of_claim, description, hours_worked, hourly_rate, " +
                             "total_work_claim, date_filled, assigned_to, status, user_contact_email) " +
                         $"VALUES ({user_Id}, '{name}', '{surname}', '{typeOfClaim}', '{description}', {hours}, {hourlyRate}, {total_work_claim}, " +
                         $"'{datefiled}', '{assignedTo}', '{status}', '{user_Email}');";


            try
            {
                //connect and open
                using (SqlConnection sqlConnects = new SqlConnection(connection.connecting()))
                {
                    //open 
                    sqlConnects.Open();

                    //PREPARE TO EXECUTE
                    using (SqlCommand command = new SqlCommand(query, sqlConnects))
                    {
                        //To prevent SQL injection
                        //command.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);
                        //command.Parameters.AddWithValue("@password", password);

                        command.ExecuteNonQuery();
                        message = "done";
                    }

                    //then close
                    sqlConnects.Close();

                }
            }
            catch (SqlException sqlError)
            {
                message = sqlError.Message;
            }
            catch (IOException error)
            {
                message = error.Message;
            }
            return message;


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

