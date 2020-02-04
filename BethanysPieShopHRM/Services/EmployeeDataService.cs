using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public EmployeeDataService( HttpClient httpClient, IHttpContextAccessor httpContextAccessor )
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _jsonSerializerOptions = 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<Employee> AddEmployee( Employee employee )
        {
            var employeeJson = new StringContent( JsonSerializer.Serialize( employee ), Encoding.UTF8, "application/json" );
            var response = await _httpClient.PostAsync( "api/employee", employeeJson );

            if ( response.IsSuccessStatusCode )
                return await JsonSerializer.DeserializeAsync<Employee>( await response.Content.ReadAsStreamAsync( ) );

            return null;
        }

        public async Task DeleteEmployee( int employeeID ) =>
            await _httpClient.DeleteAsync( $"api/employee/{employeeID}" );

        public async Task<IEnumerable<Employee>> GetAllEmployees( ) =>        
            await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync( "api/employee" ), _jsonSerializerOptions );
        

        public async Task<Employee> GetEmployeeDetails( int employeeID ) =>
            await JsonSerializer.DeserializeAsync<Employee>(
                await _httpClient.GetStreamAsync( $"api/employee/{employeeID}" ), _jsonSerializerOptions );

        public async Task UpdateEmployee( Employee employee )
        {
            var employeeJson =
                new StringContent( JsonSerializer.Serialize( employee ), Encoding.UTF8, "application/json" );

            await _httpClient.PutAsync( "api/employee", employeeJson );
        }
    }
}
