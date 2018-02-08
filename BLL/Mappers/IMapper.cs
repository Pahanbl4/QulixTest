using BLL.Models;
using DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
   public interface IMapper
    {
        WorkerModel CopyDataToModel(Worker worker);
        CompanyModel CopyDataToModel(Company company);
        Company CopyDataToCompany(CompanyModel comp);
        Worker CopyDataToWorker(WorkerModel worker);
    }
}
