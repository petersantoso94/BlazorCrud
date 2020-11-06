using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Api.Interfaces;
using BlazorServerCRUD.Api.Models;
using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void DeleteEmployee(int employeeId)
        {
            var deletedEmployee = new Employee() { EmployeeId = employeeId };
            _appDbContext.Employees.Attach(deletedEmployee);
            _appDbContext.Employees.Remove(deletedEmployee);
            _appDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }
    }
}