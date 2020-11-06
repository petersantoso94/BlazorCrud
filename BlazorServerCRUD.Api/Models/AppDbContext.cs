using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Admin" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" }
            );

            // Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { DepartmentId = 1, EmployeeId = 1, Gender = Gender.Male }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { DepartmentId = 2, EmployeeId = 2, Gender = Gender.Female }
            );
        }
    }
}