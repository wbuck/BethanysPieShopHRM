using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public JobCategoryDataService( HttpClient httpClient )
        {
            _httpClient = httpClient;

            _jsonSerializerOptions =
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories( ) =>
            await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(
                await _httpClient.GetStreamAsync( "api/jobcategory" ), _jsonSerializerOptions );

        public async Task<JobCategory> GetJobCategoryByID( int jobCategoryID ) =>
            await JsonSerializer.DeserializeAsync<JobCategory>(
                await _httpClient.GetStreamAsync( $"api/jobcategory/{jobCategoryID}" ), _jsonSerializerOptions );
    }
}
