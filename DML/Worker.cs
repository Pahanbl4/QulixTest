using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DML
{
   public class Worker
    {
        public int WorkerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime EntryDate { get; set; }

        public string Position { get; set; }

        public int CompanyId { get; set; }
    }
}
