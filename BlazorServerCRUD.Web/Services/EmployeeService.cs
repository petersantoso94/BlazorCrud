using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using BlazorServerCRUD.Web.Interfaces;

namespace BlazorServerCRUD.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _apiClient;
        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            var factory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _apiClient = factory.CreateClient("apiClient");
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _apiClient.GetJsonAsync<Employee[]>("api/employee");
        }
    }
}