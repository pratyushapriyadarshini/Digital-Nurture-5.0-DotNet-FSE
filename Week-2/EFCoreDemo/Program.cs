using EFCoreDemo.Data;
using EFCoreDemo.Models;

using var context = new AppDbContext();
// Insert sample data if table is empty
if (!context.Employees.Any())
{
    context.Employees.Add(new Employee
    {
        Name = "Pratyusha",
        Department = "AI & ML",
        Salary = 50000
    });

    context.SaveChanges();
}
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

// ================= LINQ QUERIES =================

// LINQ Query 1 - All Employees
Console.WriteLine("\n===== All Employees =====");

var allEmployees = context.Employees.ToList();

foreach (var emp in allEmployees)
{
    Console.WriteLine($"{emp.Id} {emp.Name} {emp.Department} {emp.Salary}");
}

// LINQ Query 2 - Salary > 50000
Console.WriteLine("\n===== Salary > 50000 =====");

var highSalary = context.Employees
                        .Where(e => e.Salary > 50000)
                        .ToList();

foreach (var emp in highSalary)
{
    Console.WriteLine($"{emp.Name} {emp.Salary}");
}

// LINQ Query 3 - Order By Name
Console.WriteLine("\n===== Order By Name =====");

var sorted = context.Employees
                    .OrderBy(e => e.Name)
                    .ToList();

foreach (var emp in sorted)
{
    Console.WriteLine(emp.Name);
}

// LINQ Query 4 - Select Only Names
Console.WriteLine("\n===== Employee Names =====");

var names = context.Employees
                   .Select(e => e.Name)
                   .ToList();

foreach (var name in names)
{
    Console.WriteLine(name);
}

// DELETE
var deleteEmployee = context.Employees.FirstOrDefault(e => e.Id == 1);

if (deleteEmployee != null)
{
    context.Employees.Remove(deleteEmployee);
    context.SaveChanges();
    Console.WriteLine("Employee Deleted Successfully!");
}