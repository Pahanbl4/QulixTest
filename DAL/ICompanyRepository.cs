using DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface ICompanyRepository
    {
        void AddCompany(Company company);

        void EditCompany(int id, Company company);

        void DeleteCompany(int id);

        Company GetCompany(int id);

        IEnumerable<Company> GetAllCompanies();
    }
}
