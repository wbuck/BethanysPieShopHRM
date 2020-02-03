using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public EmployeeDataService( HttpClient httpClient )
        {
            _httpClient = httpClient;

            _jsonSerializerOptions = 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public Task<Employee> AddEmployee( Employee employee ) => throw new NotImplementedException( );

        public Task DeleteEmployee( int employeeID ) => throw new NotImplementedException( );

        public async Task<IEnumerable<Employee>> GetAllEmployees( ) =>        
            await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync( "api/employee" ), _jsonSerializerOptions );
        

        public async Task<Employee> GetEmployeeDetails( int employeeID ) =>
            await JsonSerializer.DeserializeAsync<Employee>(
                await _httpClient.GetStreamAsync( $"api/employee/{employeeID}" ), _jsonSerializerOptions );

        public Task UpdateEmployee( Employee employee ) => throw new NotImplementedException( );
    }
}
