using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Parameter]
        public string EmployeeID { get; set; }

        public Employee Employee { get; set; } = new Employee( );

        public List<Country> Countries { get; set; } = new List<Country>( );

        protected string CountryID { get; set; } = string.Empty;

        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>( );

        protected string JobCategoryID { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync( )
        {
            Employee = await EmployeeDataService.GetEmployeeDetails( int.Parse( EmployeeID ) );
            Countries = ( await CountryDataService.GetAllCountries( ) ).ToList( );
            CountryID = Employee.CountryId.ToString( );
            JobCategories = ( await JobCategoryDataService.GetAllJobCategories( ) ).ToList( );
            JobCategoryID = Employee.JobCategoryId.ToString( );            
            await base.OnInitializedAsync( );
        }
    }
}
