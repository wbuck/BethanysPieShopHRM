using BethanysPieShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries( );
        Task<Country> GetCountryByID( int countryID );
    }
}