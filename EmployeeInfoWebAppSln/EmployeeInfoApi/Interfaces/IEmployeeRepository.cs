using EmployeeInfoApi.Models;

namespace EmployeeInfoApi.Interfaces
{
    public interface IEmployeeRepository
    {
        bool DoesItemExist(int personid);

        IEnumerable<Person> All { get; }

        
        Person Find(int personid);

        
        void Insert(Person person);

        void Update(Person person);

        void Delete(int personid);


    }
}
