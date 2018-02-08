using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Models;
using DML;

namespace BLL.Mappers
{
    public class Mapper : IMapper
    {
        public Company CopyDataToCompany(CompanyModel company)
        {
            return new Company()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                CompanySize = company.CompanySize,
                OrganizationalLegalForm = company.OrganizationalLegalForm,
            };
        }

        public WorkerModel CopyDataToModel(Worker worker)
        {
            return new WorkerModel()
            {
                WorkerId = worker.WorkerId,
                LastName = worker.LastName,
                FirstName = worker.FirstName,
                Patronymic = worker.Patronymic,
                EntryDate = worker.EntryDate,
                Position = worker.Position,
                CompanyId = worker.CompanyId,
            };
        }

        public Worker CopyDataToWorker(WorkerModel worker)
        {
            return new Worker()
            {
                WorkerId = worker.WorkerId,
                LastName = worker.LastName,
                FirstName = worker.FirstName,
                Patronymic = worker.Patronymic,
                EntryDate = worker.EntryDate,
                Position = worker.Position,
                CompanyId = worker.CompanyId,
            };
        }

        public CompanyModel CopyDataToModel(Company company)
        {
            return new CompanyModel()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                CompanySize = company.CompanySize,
                OrganizationalLegalForm = company.OrganizationalLegalForm,
            };
        }

       
    }
}