using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInfoApi.Models
{
    public class Person
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        //Foreign Key
        public int Employee_Person { get; set; }

        //Navigation property
        public Employee Employees{ get; set; }
    }
}
