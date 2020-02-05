using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    [Authorize]
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeID { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public Employee Employee { get; set; } = new Employee( );

        protected override async Task OnInitializedAsync( )
        {
            Employee = await EmployeeDataService.GetEmployeeDetails( int.Parse( EmployeeID ) );
            MapMarkers.Add( new Marker 
            {
                Description = $"{Employee.FirstName} {Employee.LastName}",
                ShowPopup = false,
                X = Employee.Longitude, 
                Y = Employee.Latitude } 
            );
            await base.OnInitializedAsync( );
        }

        public List<Marker> MapMarkers { get; set; } = new List<Marker>( );
    }
}
