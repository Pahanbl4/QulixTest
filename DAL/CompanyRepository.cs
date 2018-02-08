using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DML;

namespace DAL
{
    public class CompanyRepository :ContextRepository, ICompanyRepository
    {
        public CompanyRepository(string connectionString) : base(connectionString)
        {
        }

        public void AddCompany(Company company)
        {
            string request = $"INSERT INTO Company (Name, CompanySize, OrganizationalLegalForm) VALUES" +
                                $"('{company.Name}'," +
                                $"{company.CompanySize}," +
                                $"'{company.OrganizationalLegalForm}')";
            Execute(request);
        }

        public void DeleteCompany(int id)
        {
            string request = $"DELETE FROM Company WHERE CompanyId = {id}";
            Execute(request);
        }

        public void EditCompany(int id, Company company)
        {
            string request =
                $"UPDATE Company SET Name = '{company.Name}', " +
                                   $"CompanySize = {company.CompanySize}, " +
                                   $"OrganizationalLegalForm = '{company.OrganizationalLegalForm}'" +
                $"WHERE CompanyId = {id}";
            Execute(request);
        }

        public Company GetCompany(int id)
        {
            string request = $"SELECT * FROM Company WHERE CompanyId = {id}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                return new Company()
                {
                    CompanyId = (int)dataReader["CompanyId"],
                    Name = (string)dataReader["Name"],
                    CompanySize = (int)dataReader["CompanySize"],
                    OrganizationalLegalForm = (string)dataReader["OrganizationalLegalForm"]
                };
            }
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            string request = "SELECT * FROM Company";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    companies.Add(new Company()
                    {
                        CompanyId = (int)dataReader["CompanyId"],
                        Name = (string)dataReader["Name"],
                        CompanySize = (int)dataReader["CompanySize"],
                        OrganizationalLegalForm = (string)dataReader["OrganizationalLegalForm"]
                    });
                }
            }
            return companies;
        }

       
    }
}
