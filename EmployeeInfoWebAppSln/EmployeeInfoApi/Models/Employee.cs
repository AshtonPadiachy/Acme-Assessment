using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInfoApi.Models
{
    public class Employee
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        
        public int PersonId { get; set; }

        public string EmployeeNum { get; set; }
        
        public DateTime EmployedDate { get; set; }

        public DateTime? Terminated { get; set; }

    }

   
}
