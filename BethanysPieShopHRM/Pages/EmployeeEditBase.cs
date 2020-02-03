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

        [Parameter]
        public string EmployeeID { get; set; }

        public Employee Employee { get; set; } = new Employee( );

        protected override async Task OnInitializedAsync( )
        {
            Employee = await EmployeeDataService.GetEmployeeDetails( int.Parse( EmployeeID ) );
            await base.OnInitializedAsync( );
        }
    }
}
