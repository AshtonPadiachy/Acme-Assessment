using EmployeeInfoApi.Data;
using EmployeeInfoApi.Interfaces;
using EmployeeInfoApi.Models;

namespace EmployeeInfoApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

       // public IEnumerable<Person> All => throw new NotImplementedException();
       // public EmployeeContext EmployeeContext => _employeeContext;

        public IEnumerable<Person> All
        {
            get { return _employeeContext.Persons.ToList(); }
        }

        public void Delete(int personid)
        {
            
            _employeeContext.Persons.Remove(this.Find(personid));
            _employeeContext.SaveChanges();
        }

        public bool DoesItemExist(int personid)
        {
            return _employeeContext.Persons.Any(person => person.PersonId == personid); 
        }

        public Person Find(int personid)
        {
            return _employeeContext.Persons.FirstOrDefault(person => person.PersonId == personid);
        }

        public void Insert(Person person)
        {
            _employeeContext.Persons.Add(person);
            _employeeContext.SaveChanges();
        }

        public void Update(Person person)
        {
            var personOne = this.Find(person.PersonId);

            personOne.LastName = person.LastName;
            personOne.FirstName = person.FirstName;
            personOne.BirthDate = person.BirthDate;
            _employeeContext.Persons.Update(personOne);
            _employeeContext.SaveChanges();
            
        }
    }
}
