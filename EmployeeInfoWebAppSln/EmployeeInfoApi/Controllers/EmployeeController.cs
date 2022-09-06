using EmployeeInfoApi.Data;
using EmployeeInfoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeecontext;
        public EmployeeController(EmployeeContext employeecontext) => _employeecontext = employeecontext;
         
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        
            => await _employeecontext.Persons.ToListAsync();

        [HttpGet("{personid}")]
       // [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
       // [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int personid)
        {
            var employee = await _employeecontext.Persons.FindAsync(personid);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
       // [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Person employee)
        {
            await _employeecontext.Persons.AddAsync(employee);
            await _employeecontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {personid = employee.PersonId}, employee);
        }

        [HttpPut("{personid}")]
       // [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int personid, Person employee)
        {
            if (personid != employee.PersonId) return BadRequest();

            _employeecontext.Entry(employee).State = EntityState.Modified;
            await _employeecontext.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{personid}")]
       // [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int personid)
        {
            var employeeToDelete = await _employeecontext.Persons.FindAsync(personid);
                if (employeeToDelete == null) return NotFound();

                _employeecontext.Persons.Remove(employeeToDelete);
            await _employeecontext.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
