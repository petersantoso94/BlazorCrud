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
            var hrDepartment = new Department { DepartmentId = 2, DepartmentName = "HR" };
            var adminDepartment = new Department { DepartmentId = 1, DepartmentName = "Admin" };
            modelBuilder.Entity<Department>().HasData(
                adminDepartment
            );
            modelBuilder.Entity<Department>().HasData(
                hrDepartment
            );

            // Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { DepartmentId = 1, EmployeeId = 1, EmployeeName = "John", Gender = Gender.Male }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Lisa", Gender = Gender.Female }
            );
        }
    }
}