using EmployeeInfoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfoApi.Data
{
    public class EmployeeContext
        :DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
           : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
