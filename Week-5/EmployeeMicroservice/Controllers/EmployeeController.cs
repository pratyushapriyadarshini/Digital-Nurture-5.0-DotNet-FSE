using EmployeeMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeeMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Pratyusha",
                Salary = 50000,
                DepartmentId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Salary = 45000,
                DepartmentId = 2
            }
        };

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"http://localhost:5275/api/Department/{employee.DepartmentId}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Department service unavailable");

            var json = await response.Content.ReadAsStringAsync();

            var department = JsonSerializer.Deserialize<DepartmentDto>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            var result = new EmployeeWithDepartment
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Department = department
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok("Employee Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.DepartmentId = updatedEmployee.DepartmentId;

            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employees.Remove(employee);

            return Ok("Employee Deleted Successfully");
        }
    }
}