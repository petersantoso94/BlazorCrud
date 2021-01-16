using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using BlazorServerCRUD.Web.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BlazorServerCRUD.Web.Services
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly HttpClient _apiClient;
        private readonly ApiConfigDTO _apiConfig;
        public RandomNumberService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            var factory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            var conf = config ?? throw new ArgumentNullException(nameof(config));
            _apiClient = factory.CreateClient("apiClient");
            _apiConfig = conf.GetSection("Api").Get<ApiConfigDTO>();
        }
        public List<string> GetRandomNumber()
        {
            var result = new List<string>();
            var listTasks = new List<Task>();
            for (int i = 0; i < 500; i++)
            {
                var task = new Task(() => result.Add(_apiClient.GetStringAsync("api/randomnumber").GetAwaiter().GetResult()));
                task.Start();
                listTasks.Add(task);
            }
            Task.WhenAll(listTasks).Wait();
            return result;
        }
    }
}