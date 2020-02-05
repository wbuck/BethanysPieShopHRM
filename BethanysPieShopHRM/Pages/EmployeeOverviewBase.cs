using BethanysPieShopHRM.Components;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    [Authorize]
    public class EmployeeOverviewBase : ComponentBase
    {

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync( )
        {
            Employees = await EmployeeDataService.GetAllEmployees( );
            await base.OnInitializedAsync( );
        }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        protected async Task QuickAddEmployee( )
        {
            var authenticationState = await AuthenticationStateTask;
            if ( authenticationState.User.Identity.Name.CompareTo( "Warren") == 0 )
                AddEmployeeDialog.Show( );
        }

        public async void OnDialogClose( )
        {
            Employees = ( await EmployeeDataService.GetAllEmployees( ) ).ToList( );
            StateHasChanged( );
        }

    }
}
