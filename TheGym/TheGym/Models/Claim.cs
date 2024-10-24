using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

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
        public string? TypeOfClaim { get; set; }

        /// <summary>
        //[Required(ErrorMessage = "Type Of Claim is required")]
        /// </summary>
        [DataType(DataType.Text)]
        [MaxLength(500, ErrorMessage = "Claim description cannot exceed 500 characters")]
        public string? ClaimDescription { get; set; }

        [Required(ErrorMessage = "Hours worked are required")]
        [Range(1, 24, ErrorMessage = "Hours worked must be between 1 and 24")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Hourly rate must be between 0.01 and 1000.00")]
        public decimal HourlyRate { get; set; }

        [Required(ErrorMessage = "Claim amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Claim amount must be greater than 0")]
        public decimal ClaimAmount { get; set; }  // Claim amount

        [Required(ErrorMessage = "Claim month is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DateFiled { get; set; } // Date of the claim

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public string? Status { get; set; }    // Claim status: Pending, Approved, Denied

        [Required(ErrorMessage = "Member ID is required")]
        public int MemberID { get; set; }  // Foreign Key to Member

        [Required(ErrorMessage = "Contract ID is required")]
        public int ContractID { get; set; }  // Foreign Key for Contract

        public Contract? Contract { get; set; }  // Relationship with Contract

        public List<Payment> Payments { get; set; }  // Relationship with Payments




        Connection connection = new Connection();

        //Method to check user
        public string InsertClaim(string usernameOrEmail, string password)
        {
            //temp message
            string message = "";

            try
            {
                //connect and open
                using (SqlConnection sqlonnects = new SqlConnection(connection.connecting()))
                {
                    //open 
                    sqlonnects.Open();



                    //query 
                    string query;
                    //Retrieve to the sign up data
                    //Condtion to check if it is a email or username to run each specific query
                    if (usernameOrEmail.Contains("@"))
                    {
                        query = "SELECT * FROM users WHERE user_email = '" + usernameOrEmail + "' and user_password ='" + password + "';";
                    }
                    else
                    {
                        query = "SELECT * FROM users WHERE user_name = '" + usernameOrEmail + "' and user_password ='" + password + "';";
                    }

                    /*
                   //check if it recieves data"
                   Console.WriteLine(emaill + " AND " + password);
                   */

                    using (SqlCommand command = new SqlCommand(query, sqlonnects))
                    {
                        //To prevent SQL injection
                        command.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);
                        command.Parameters.AddWithValue("@password", password);

                        //read the data
                        using (SqlDataReader find_user = command.ExecuteReader())
                        {

                            //then check if user is Found
                            if (find_user.HasRows)
                            {
                                //true when found
                                message = "found";

                            }
                            else
                            {
                                //false when found
                                message = "not";
                            }
                        }
                    }

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

    }

}

