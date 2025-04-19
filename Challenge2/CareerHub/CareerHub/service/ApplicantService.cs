using System;
using System.IO;
using System.Text.RegularExpressions;
using CareerHub.dao;
using CareerHub.entity;
using CareerHub.exception;

namespace CareerHub.service
{
    public class ApplicantService
    {
        private ApplicantDAO applicantDAO = new ApplicantDAO();
        public void RegisterApplicant(string email)
        {
            try
            {
                if (!IsValidEmail(email))
                    throw new CareerHubException("Invalid Email Format. Please enter a valid email address (example@example.com).");

                Console.WriteLine("email registered successfully " + email);
            }
            catch (CareerHubException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public void AddApplicant(Applicant applicant)
        {
            if (string.IsNullOrWhiteSpace(applicant.FirstName))
                throw new CareerHubException("First Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(applicant.LastName))
                throw new CareerHubException("Last Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(applicant.Phone))
                throw new CareerHubException("Phone Number cannot be empty.");
            applicantDAO.AddApplicant(applicant); 
            Console.WriteLine("Applicant successfully added.");
        }

        public void SubmitApplication(DateTime applicationDate, DateTime deadline)
        {
            try
            {
                if (applicationDate > deadline)
                    throw new CareerHubException("Application deadline has passed. Cannot accept late applications.");

                Console.WriteLine(" Application submitted successfully!");
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
        public void UploadResume(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new CareerHubException("File not found.");

                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 1048576)
                    throw new CareerHubException(" File size exceeds the 1 MB limit.");

                string extension = fileInfo.Extension.ToLower();
                if (extension != ".pdf" && extension != ".docx")
                    throw new CareerHubException(" Unsupported file format. Only .pdf and .docx are allowed.");

                Console.WriteLine($" Resume uploaded successfully: {fileInfo.Name}");
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

private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}

