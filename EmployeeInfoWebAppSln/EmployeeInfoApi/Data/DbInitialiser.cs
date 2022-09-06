using EmployeeInfoApi.Models;

namespace EmployeeInfoApi.Data
{
    public class DbInitialiser
    {
       private readonly EmployeeContext _context;

        public DbInitialiser(EmployeeContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if(!_context.Persons.Any())
            {

                var person = new Person();
                person.LastName = "Matthew";
                person.FirstName = "Luke";
                person.BirthDate = DateTime.Now;

                var employee = new Employee();
                employee.EmployeeNum = "1231231";
                employee.EmployedDate = DateTime.Now;
                employee.Terminated = DateTime.Now;

                _context.Persons.Add(person);
                _context.Employees.Add(employee);

                var person1 = new Person();
                person1.LastName = "Piet";
                person1.FirstName = "Chanel";
                person1.BirthDate = DateTime.Now;

                var employee1 = new Employee();
                employee1.EmployeeNum = "5344535";
                employee1.EmployedDate = DateTime.Now;
                employee1.Terminated = DateTime.Now;

                _context.Persons.Add(person1);
                _context.Employees.Add(employee1);


                _context.SaveChanges();

            }
        }
    }
}
