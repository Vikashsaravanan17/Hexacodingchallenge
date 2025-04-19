using System;
using System.Collections.Generic;
using CareerHub.entity;
using CareerHub.dao;
using CareerHub.exception;

namespace CareerHub.service
{
    public class JobListingService
    {
        private JobListingDAO jobDAO = new JobListingDAO();

        public void AddJob(JobListing job)
        {
            if (job.Salary < 0)
                throw new CareerHubException("Salary cannot be negative.");
            if (string.IsNullOrWhiteSpace(job.JobTitle))
                throw new CareerHubException("Job title cannot be empty.");

            jobDAO.AddJob(job);
            Console.WriteLine("Job successfully added.");
        }

        public void DisplayAllJobs()
        {
            List<JobListing> jobs = jobDAO.GetAllJobs();
            if (jobs.Count == 0)
            {
                Console.WriteLine("No job listings found.");
                return;
            }

            foreach (var job in jobs)
            {
                Console.WriteLine($"[{job.JobID}] {job.JobTitle} | {job.JobLocation} | {job.Salary:C}");
            }
        }

        public void DisplayJobById(int id)
        {
            try
            {
                JobListing job = jobDAO.GetJobById(id);
                Console.WriteLine("--------- Job Details ---------");
                Console.WriteLine($"ID        : {job.JobID}");
                Console.WriteLine($"Title     : {job.JobTitle}");
                Console.WriteLine($"CompanyID : {job.CompanyID}");
                Console.WriteLine($"Location  : {job.JobLocation}");
                Console.WriteLine($"Salary    : {job.Salary:C}");
                Console.WriteLine($"Type      : {job.JobType}");
                Console.WriteLine($"Posted On : {job.PostedDate:d}");
                Console.WriteLine("--------------------------------");
            }

            catch (CareerHubException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CalculateAverageSalary()
        {
            try
            {
                List<JobListing> jobs = jobDAO.GetAllJobs();
                if (jobs.Count == 0)
                {
                    Console.WriteLine("No job listings found.");
                    return;
                }

                decimal totalSalary = 0;
                int count = 0;

                foreach (var job in jobs)
                {
                    if (job.Salary < 0)
                    {
                        Console.WriteLine($"⚠️  Invalid salary for Job ID {job.JobID} : {job.Salary:C}");
                        continue;  // skip this job
                    }

                    totalSalary += job.Salary;
                    count++;
                }

                if (count == 0)
                {
                    Console.WriteLine("No valid salary data available.");
                    return;
                }

                decimal averageSalary = totalSalary / count;
                Console.WriteLine($"\n✅ Average Salary: {averageSalary:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating average salary: " + ex.Message);
            }
        }
    }
}


