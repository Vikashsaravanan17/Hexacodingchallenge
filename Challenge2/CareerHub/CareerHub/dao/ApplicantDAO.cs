using System.Collections.Generic;
using System.Data.SqlClient;
using CareerHub.entity;
using CareerHub.util;

namespace CareerHub.dao
{
    public class ApplicantDAO
    {
        public void AddApplicant(Applicant applicant)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "INSERT INTO Applicants (FirstName, LastName, Email, Phone, Resume) " +
                               "VALUES (@FirstName, @LastName, @Email, @Phone, @Resume)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                cmd.Parameters.AddWithValue("@Email", applicant.Email);
                cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                cmd.Parameters.AddWithValue("@Resume", applicant.Resume);

                cmd.ExecuteNonQuery();
            }
        }
        public List<Applicant> GetAllApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Applicants";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Applicant applicant = new Applicant
                    {
                        ApplicantID = (int)reader["ApplicantID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Resume = reader["Resume"].ToString()
                    };
                    applicants.Add(applicant);
                }
            }

            return applicants;
        }
    }
}

