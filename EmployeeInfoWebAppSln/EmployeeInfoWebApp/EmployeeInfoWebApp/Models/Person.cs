using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInfoWebApp.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int PersonId { get; set; }
        
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime EmployedDate { get; set; }

        public DateTime Terminated { get; set; }

        //Foreign Key
        // public int Employee_Person { get; set; }

        //Navigation property
        // public Employee Employees { get; set; }


    }
}
