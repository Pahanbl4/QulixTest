using DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IWorkerRepository
    {
        void AddWorker(Worker worker);

        void EditWorker(int id, Worker worker);

        void DeleteWorker(int id);

        Worker GetWorker(int id);

        IEnumerable<Worker> GetAllWorkers();
    }
}
