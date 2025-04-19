using System.Collections.Generic;
using CareerHub.entity;

namespace CareerHub.dao
{
    public class CompanyDAO
    {
        private List<Company> companies = new List<Company>();

        public void AddCompany(Company company)
        {
            companies.Add(company);
        }

        public List<Company> GetAllCompanies()
        {
            return companies;
        }
    }
}

