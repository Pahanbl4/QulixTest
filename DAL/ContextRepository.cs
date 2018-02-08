using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ContextRepository 
    {
        protected string connectionString;

        public ContextRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected void Execute(string expression)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                command.ExecuteNonQuery();
            }
        }

       
    }
}
