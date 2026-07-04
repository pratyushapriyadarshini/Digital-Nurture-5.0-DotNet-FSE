using Microsoft.EntityFrameworkCore;
using EFCoreDemo.Models;

namespace EFCoreDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=EFCoreDemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}