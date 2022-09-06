using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInfoWebApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime EmployedDate { get; set; }

        public DateTime Terminated { get; set; }
    }
}
