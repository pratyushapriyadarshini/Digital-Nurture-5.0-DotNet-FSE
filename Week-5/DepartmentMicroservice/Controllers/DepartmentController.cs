using Microsoft.AspNetCore.Mvc;
using DepartmentMicroservice.Models;

namespace DepartmentMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        // Temporary in-memory data
        private static List<Department> departments = new List<Department>
        {
            new Department { Id = 1, Name = "AI & ML", Location = "Bhubaneswar" },
            new Department { Id = 2, Name = "HR", Location = "Hyderabad" }
        };

        // GET: api/Department
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(departments);
        }

        // GET: api/Department/1
        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound("Department not found");

            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            departments.Add(department);

            return Ok("Department Added Successfully");
        }

        // PUT: api/Department/1
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, Department updatedDepartment)
        {
            var department = departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound("Department not found");

            department.Name = updatedDepartment.Name;
            department.Location = updatedDepartment.Location;

            return Ok("Department Updated Successfully");
        }

        // DELETE: api/Department/1
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound("Department not found");

            departments.Remove(department);

            return Ok("Department Deleted Successfully");
        }
    }
}