namespace EmployeeMicroservice.Models
{
    public class EmployeeWithDepartment
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DepartmentDto? Department { get; set; }
    }
}