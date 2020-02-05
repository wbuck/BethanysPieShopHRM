using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    [Authorize]
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeID { get; set; }

        public Employee Employee { get; set; } = new Employee( );

        public List<Country> Countries { get; set; } = new List<Country>( );

        protected string CountryID { get; set; } = string.Empty;

        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>( );

        protected string JobCategoryID { get; set; } = string.Empty;

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync( )
        {
            Saved = false;
            Countries = ( await CountryDataService.GetAllCountries( ) ).ToList( );
            JobCategories = ( await JobCategoryDataService.GetAllJobCategories( ) ).ToList( );

            if ( !int.TryParse( EmployeeID, out int employeeID ) )
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now };
            else
                Employee = await EmployeeDataService.GetEmployeeDetails( employeeID );

            CountryID = Employee.CountryId.ToString( );
            JobCategoryID = Employee.JobCategoryId.ToString( );            
            await base.OnInitializedAsync( );
        }

        protected async Task HandleValidSubmit( )
        {
            Employee.CountryId = int.Parse( CountryID );
            Employee.JobCategoryId = int.Parse( JobCategoryID );

            if ( Employee.EmployeeId ==  0 )
            {
                var addedEmployee = await EmployeeDataService.AddEmployee( Employee );
                if ( addedEmployee != null )
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding a new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee( Employee );
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        protected async Task DeleteEmployee( )
        {
            await EmployeeDataService.DeleteEmployee( Employee.EmployeeId );
            StatusClass = "alert-sucess";
            Message = "Deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview( )
        {
            NavigationManager.NavigateTo( "/employeeoverview" );
        }
    }
}
