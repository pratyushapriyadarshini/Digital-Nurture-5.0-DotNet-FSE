using EFCoreDemo.Data;
using EFCoreDemo.Models;

using var context = new AppDbContext();

Console.WriteLine("===== Employees =====");

// READ
var employees = context.Employees.ToList();

foreach (var emp in employees)
{
    Console.WriteLine($"{emp.Id} {emp.Name} {emp.Department} {emp.Salary}");
}

// UPDATE
var employee = context.Employees.FirstOrDefault(e => e.Id == 1);

if (employee != null)
{
    employee.Salary = 60000;
    context.SaveChanges();
    Console.WriteLine("Employee Updated Successfully!");
}

// DELETE
var deleteEmployee = context.Employees.FirstOrDefault(e => e.Id == 1);

if (deleteEmployee != null)
{
    context.Employees.Remove(deleteEmployee);
    context.SaveChanges();
    Console.WriteLine("Employee Deleted Successfully!");
}