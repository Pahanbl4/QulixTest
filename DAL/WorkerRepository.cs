using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DML;

namespace DAL
{
    public class WorkerRepository :ContextRepository, IWorkerRepository
    {
        public WorkerRepository(string connectionString) : base(connectionString)
        {
        }

        public void AddWorker(Worker worker)
        {
            string request = $"INSERT INTO Worker (LastName, FirstName, Patronymic,EntryDate, Position, CompanyId) VALUES" +
                                $"('{worker.LastName}'," +
                                $"'{worker.FirstName}'," +
                                $"'{worker.Patronymic}'," +
                                $"convert(date,'{worker.EntryDate}',104)," +
                                $"'{worker.Position}'," +
                                $"{worker.CompanyId})";
            Execute(request);
        }

        public void DeleteWorker(int id)
        {
            string request = $"DELETE FROM Worker WHERE WorkerId = {id}";
            Execute(request);
        }

        public void EditWorker(int id, Worker worker)
        {
            string request =
                $"UPDATE Worker SET LastName = '{worker.LastName}', " +
                                  $"FirstName = '{worker.FirstName}', " +
                                  $"Patronymic = '{worker.Patronymic}', " +
                                  $"EntryDate = convert(date,'{worker.EntryDate}',104)," +
                                  $"Position = '{worker.Position}', " +
                                  $"CompanyId = {worker.CompanyId} " +
                $"WHERE WorkerId = {worker.WorkerId}";
            Execute(request);
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();
            string request = $"SELECT * FROM Worker";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    workers.Add(new Worker()
                    {
                        WorkerId = (int)dataReader["WorkerId"],
                        FirstName = (string)dataReader["FirstName"],
                        LastName = (string)dataReader["LastName"], 
                        Patronymic = (string)dataReader["Patronymic"],
                        EntryDate = (DateTime)dataReader["EntryDate"],
                        Position = (string)dataReader["Position"],
                        CompanyId = (int)dataReader["CompanyId"]
                    });
                }
            }
            return workers;
        }

        public Worker GetWorker(int id)
        {
            string request = $"SELECT * FROM Worker WHERE WorkerId = {id}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                return new Worker()
                {
                    WorkerId = (int)dataReader["WorkerId"],
                    FirstName = (string)dataReader["FirstName"],
                    LastName = (string)dataReader["LastName"],
                    Patronymic = (string)dataReader["Patronymic"],
                    EntryDate = (DateTime)dataReader["EntryDate"],
                    Position = (string)dataReader["Position"],
                    CompanyId = (int)dataReader["CompanyId"]
                };
            }
        }


    }
}
