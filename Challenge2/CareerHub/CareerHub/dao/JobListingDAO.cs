using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CareerHub.entity;
using CareerHub.exception;
using CareerHub.util;

namespace CareerHub.dao
{
    public class JobListingDAO
    {
        public void AddJob(JobListing job)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "INSERT INTO Jobs (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                               "VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompanyID", job.CompanyID);
                cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                cmd.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                cmd.Parameters.AddWithValue("@JobLocation", job.JobLocation);
                cmd.Parameters.AddWithValue("@Salary", job.Salary);
                cmd.Parameters.AddWithValue("@JobType", job.JobType);
                cmd.Parameters.AddWithValue("@PostedDate", job.PostedDate);

                cmd.ExecuteNonQuery();
            }
        }


        public List<JobListing> GetAllJobs()
        {
            List<JobListing> jobs = new List<JobListing>();

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    JobListing job = new JobListing
                    {
                        JobID = (int)reader["JobID"],
                        CompanyID = (int)reader["CompanyID"],
                        JobTitle = reader["JobTitle"].ToString(),
                        JobDescription = reader["JobDescription"].ToString(),
                        JobLocation = reader["JobLocation"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        JobType = reader["JobType"].ToString(),
                        PostedDate = (DateTime)reader["PostedDate"]
                    };
                    jobs.Add(job);
                }
            }
            return jobs;
        }

        public JobListing GetJobById(int id)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Jobs WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new JobListing
                    {
                        JobID = (int)reader["JobID"],
                        CompanyID = (int)reader["CompanyID"],
                        JobTitle = reader["JobTitle"].ToString(),
                        JobDescription = reader["JobDescription"].ToString(),
                        JobLocation = reader["JobLocation"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        JobType = reader["JobType"].ToString(),
                        PostedDate = (DateTime)reader["PostedDate"]
                    };
                }
                else
                {
                    throw new CareerHubException("Job not found with ID: " + id);
                }
            }
        }
    }
}
