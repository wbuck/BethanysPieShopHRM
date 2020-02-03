using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CountryDataService( HttpClient httpClient )
        {
            _httpClient = httpClient;

            _jsonSerializerOptions =
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Country>> GetAllCountries( ) =>
            await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                await _httpClient.GetStreamAsync( "api/country" ), _jsonSerializerOptions );

        public async Task<Country> GetCountryByID( int countryID ) =>
            await JsonSerializer.DeserializeAsync<Country>(
                await _httpClient.GetStreamAsync( $"api/country/{countryID}" ), _jsonSerializerOptions );
    }
}
