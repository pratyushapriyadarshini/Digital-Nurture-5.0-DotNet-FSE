using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Filters;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Pratyusha",
                Department = "AI & ML",
                Salary = 60000
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Department = "HR",
                Salary = 45000
            }
        };

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        // PUT: api/Employee/1
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            emp.Name = updatedEmployee.Name;
            emp.Department = updatedEmployee.Department;
            emp.Salary = updatedEmployee.Salary;

            return Ok(emp);
        }

        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            employees.Remove(emp);

            return Ok("Employee Deleted Successfully");
        }
    }
}