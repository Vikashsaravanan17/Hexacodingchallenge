using System;
using CareerHub.entity;
using CareerHub.service;
using CareerHub.exception;

namespace CareerHub
{
    class Program
    {
        static void Main(string[] args)
        {
            JobListingService jobService = new JobListingService();
            ApplicantService applicantService = new ApplicantService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n====== CareerHub Job Board ======");
                Console.WriteLine("1. Add Job Listing");
                Console.WriteLine("2. View All Jobs");
                Console.WriteLine("3. View Job By ID");
                Console.WriteLine("4. Add Applicant");
                Console.WriteLine("5. Calculate Average Salary");
                Console.WriteLine("6. Submit Job Application");
                Console.WriteLine("7. Exit");
                Console.Write("Choose your option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddJob(jobService);
                            break;
                        case "2":
                            jobService.DisplayAllJobs();
                            break;
                        case "3":
                            ViewJobById(jobService);
                            break;
                        case "4":
                            Console.Write("Enter Applicant First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Applicant Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Applicant Email: ");
                            string email = Console.ReadLine();
                            applicantService.RegisterApplicant(email);
                            Console.Write("Enter Applicant Phone Number: ");
                            string phone = Console.ReadLine();
                            Console.Write("Enter file path to upload resume: ");
                            string filePath = Console.ReadLine();
                            applicantService.UploadResume(filePath);

                            Applicant applicant = new Applicant
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                Phone = phone,
                            };

                            applicantService.AddApplicant(applicant);
                            break;

                        case "5":
                            jobService.CalculateAverageSalary();
                            break;

                        case "6":
                            Console.Write("Enter application deadline (yyyy-MM-dd): ");
                            DateTime deadline = DateTime.Parse(Console.ReadLine());
                            DateTime applicationDate = DateTime.Now;
                            applicantService.SubmitApplication(applicationDate, deadline);
                            break;

                        case "7":
                            exit = true;
                            Console.WriteLine("Exiting CareerHub. Goodbye!");
                            break;

                        case "8":
                            exit = true;
                            Console.WriteLine("Exiting CareerHub. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1-4.");
                            break;

                    }
                }
                catch (CareerHubException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }

        static void AddJob(JobListingService jobService)
        {
            Console.Write("Enter Job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Company ID: ");
            int companyID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Job Title: ");
            string jobTitle = Console.ReadLine();

            Console.Write("Enter Job Description: ");
            string jobDescription = Console.ReadLine();

            Console.Write("Enter Job Location: ");
            string jobLocation = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Job Type (Full-time/Part-time/Contract): ");
            string jobType = Console.ReadLine();

            DateTime postedDate = DateTime.Now;

            JobListing newJob = new JobListing(jobID, companyID, jobTitle, jobDescription, jobLocation, salary, jobType, postedDate);
            jobService.AddJob(newJob);
        }

        static void ViewJobById(JobListingService jobService)
        {
            Console.Write("Enter Job ID to search: ");
            int jobID = Convert.ToInt32(Console.ReadLine());
            jobService.DisplayJobById(jobID);
        }
    }
}
